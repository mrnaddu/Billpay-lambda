using Billpay_lambda.Consts;
using Billpay_lambda.Exceptions;
using Billpay_lambda.Helpers;
using Billpay_lambda.InputDtos;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Managers;

public class BillPayManager
{
    public ResultDto<List<AtmDto>> GetNearByTerminal(double lat, double lng)
    {
        try
        {
            var atmList = AtmHelper.GetAllAtms();
            if (atmList.Count == 0)
                throw new NotFoundException("There is error while fetching atm list");

            var matchingAtms = atmList.Where(atm => atm.Lat == lat && atm.Lng == lng).ToList() ?? throw new NotFoundException($"Terminal Not found for the lattitude: {lat}, longitude: {lng}");

            return ResultDto<List<AtmDto>>.SuccessResult(matchingAtms);
        }
        catch (Exception ex)
        {
            return ResultDto<List<AtmDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<List<BillerInfoDto>> GetBillersByTerminal(Guid terminalId)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.ReferenceTerminalUid == terminalId).ToList() ?? throw new NotFoundException($"Billers Not found for selected terminal {terminalId}");

            return ResultDto<List<BillerInfoDto>>.SuccessResult(matchingBillers);
        }
        catch (Exception ex)
        {
            return ResultDto<List<BillerInfoDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<List<BillerInfoDto>> GetTopBillers(Guid terminalId)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var maxStubs = billerList.Where(biller => biller.ReferenceTerminalUid == terminalId && biller.MaxStubs >= 1 && biller.MaxStubs <= 5).ToList() ?? throw new NotFoundException($"Top billers Not found for selected terminal {terminalId}");

            return ResultDto<List<BillerInfoDto>>.SuccessResult(billerList);
        }
        catch (Exception ex)
        {
            return ResultDto<List<BillerInfoDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<BillerInfoDto> GetBiller(Guid billerId)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.ReferenceBillerUid == billerId).ToList() ?? throw new NotFoundException($"Biller Not found {billerId}");

            return ResultDto<BillerInfoDto>.SuccessResult(matchingBillers.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return ResultDto<BillerInfoDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<ProcessBillPayDto> ProcessBillpayDetails(Guid terminalId, Guid billerId, ProcessBillPayInputDto input)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers()

                ?? throw new NotFoundException("There is error while fetching biller list");
            var matchingBillers = billerList.Where(biller => biller.ReferenceBillerUid == billerId
            && biller.ReferenceTerminalUid == terminalId).FirstOrDefault()

            ?? throw new NotFoundException($"Biller Not found for selected terminal {terminalId} and biller {billerId}");

            #region Without extra data
            // Without ExtraData fileds
            if (matchingBillers.IsExtraData == false
                && input.ScreenData.ScreenType == ScreenTypes.WithoutExtraData
                && input.ScreenData.DataElements == null)
            {
                var withoutExtraData = ProcessBillPayHelper.GetWithoutExtraData(terminalId, billerId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(withoutExtraData);
            }

            // Without ExtraData for compliance
            if (matchingBillers.IsExtraData == false
                && input.ScreenData.ScreenType == ScreenTypes.WithoutExtraData

                // delivery type
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DeliveryType
                && de.Value == DataElementsValue.sameDay
                || de.Value == DataElementsValue.nextDay
                || de.Value == DataElementsValue.standardDay)

                // account number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.AccountNumber
                && !string.IsNullOrEmpty(de.Value))

                // amount
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.Amount
                && !string.IsNullOrEmpty(de.Value)
                && decimal.TryParse(de.Value, out var amount)
                && amount > 1000m)

                && input.TransactionId != Guid.Empty)
            {
                var compilance = ProcessBillPayHelper.GetCompilance(terminalId, billerId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(compilance);
            }

            // Without ExtraData for compliance validation and return transaction summary
            if (matchingBillers.IsExtraData == false
                && input.ScreenData.ScreenType == ScreenTypes.Compilance

                // delivery type
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.GovermentNumber
                && !string.IsNullOrEmpty(de.Value)
                && IsValidGovernmentNumber(de.Value))

                // account number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DateOfBirth
                && !string.IsNullOrEmpty(de.Value)
                && IsValidDateOfBirth(de.Value))

                && input.TransactionId != Guid.Empty)
            {
                var compilanceTrnsactionSummary = ProcessBillPayHelper.GetTransactionSummary(terminalId, billerId, input.TransactionId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(compilanceTrnsactionSummary);
            }

            // Without ExtraData for transaction summary
            if (matchingBillers.IsExtraData == false
                && input.ScreenData.ScreenType == ScreenTypes.TransactionSummary
                // delivery type
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DeliveryType
                && de.Value == DataElementsValue.sameDay
                || de.Value == DataElementsValue.nextDay
                || de.Value == DataElementsValue.standardDay)

                // account number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.AccountNumber
                && !string.IsNullOrEmpty(de.Value))

                // amount
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.Amount
                && !string.IsNullOrEmpty(de.Value))

                && input.TransactionId != Guid.Empty)
            {
                var transactionSummary = ProcessBillPayHelper.GetTransactionSummary(terminalId, billerId, input.TransactionId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(transactionSummary);
            }

            #endregion


            #region With Extra Data
            // With ExtraData fields
            if (matchingBillers.IsExtraData == true
                && input.ScreenData.ScreenType == ScreenTypes.WithExtraData
                && input.ScreenData.DataElements == null)
            {
                var withData = ProcessBillPayHelper.GetWithExtraData(terminalId, billerId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(withData);
            }

            // With ExtraData for basic fields
            if (matchingBillers.IsExtraData == false
                && input.ScreenData.ScreenType == ScreenTypes.WithExtraData

                // division number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DivisionNumber
                && de.Value == DataElementsValue.dev1
                || de.Value == DataElementsValue.dev2
                || de.Value == DataElementsValue.dev3)

                // states
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.SelectState
                && de.Value == DataElementsValue.NYK
                || de.Value == DataElementsValue.ALA
                || de.Value == DataElementsValue.TXS)

                // transaction id
                && input.TransactionId != Guid.Empty)
            {
                var compilance = ProcessBillPayHelper.GetWithoutExtraData(terminalId, billerId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(compilance);
            }

            // With ExtraData for compliance
            if (matchingBillers.IsExtraData == true
                && input.ScreenData.ScreenType == ScreenTypes.WithExtraData

                // delivery type
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DeliveryType
                && de.Value == DataElementsValue.sameDay
                || de.Value == DataElementsValue.nextDay
                || de.Value == DataElementsValue.standardDay)

                // account number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.AccountNumber
                && !string.IsNullOrEmpty(de.Value))

                // amount
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.Amount
                && !string.IsNullOrEmpty(de.Value)
                && decimal.TryParse(de.Value, out var amount)
                && amount > 1000m)

                && input.TransactionId != Guid.Empty)
            {
                var compilance = ProcessBillPayHelper.GetCompilance(terminalId, billerId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(compilance);
            }

            // With ExtraData for compliance validation and return transaction summary
            if (matchingBillers.IsExtraData == true
                && input.ScreenData.ScreenType == ScreenTypes.Compilance

                // delivery type
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.GovermentNumber
                && !string.IsNullOrEmpty(de.Value)
                && IsValidGovernmentNumber(de.Value))

                // account number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DateOfBirth
                && !string.IsNullOrEmpty(de.Value)
                && IsValidDateOfBirth(de.Value))

                && input.TransactionId != Guid.Empty)
            {
                var compilanceTrnsactionSummary = ProcessBillPayHelper.GetTransactionSummary(terminalId, billerId, input.TransactionId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(compilanceTrnsactionSummary);
            }

            // With ExtraData for transaction summary
            if (matchingBillers.IsExtraData == true
                && input.ScreenData.ScreenType == ScreenTypes.TransactionSummary
                // delivery type
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.DeliveryType
                && de.Value == DataElementsValue.sameDay
                || de.Value == DataElementsValue.nextDay
                || de.Value == DataElementsValue.standardDay)

                // account number
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.AccountNumber
                && !string.IsNullOrEmpty(de.Value))

                // amount
                && input.ScreenData.DataElements.Any(de => de.Label == DataElementsLabel.Amount
                && !string.IsNullOrEmpty(de.Value))

                && input.TransactionId != Guid.Empty)
            {
                var transactionSummary = ProcessBillPayHelper.GetTransactionSummary(terminalId, billerId, input.TransactionId);
                return ResultDto<ProcessBillPayDto>.SuccessResult(transactionSummary);
            }

            #endregion

            else
            {
                return ResultDto<ProcessBillPayDto>.FailureResult("No Results found for your input request , Please verify the input request");
            }
        }
        catch (Exception ex)
        {
            return ResultDto<ProcessBillPayDto>.FailureResult($"Exception: {ex.Message}");
        }
    }


    public ResultDto<List<BillerInfoDto>> GetBillerCategory(Guid terminalId)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller category list");

            var matchingCategory = billerList.Where(biller => biller.ReferenceTerminalUid == terminalId).GroupBy(cat => cat.Industries.FirstOrDefault()?.IndustryName).Select(group => group.FirstOrDefault()).ToList() ?? throw new NotFoundException($"Terminal Not found for selected terminal {terminalId}");

            return ResultDto<List<BillerInfoDto>>.SuccessResult(matchingCategory);
        }
        catch (Exception ex)
        {
            return ResultDto<List<BillerInfoDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<String> StoreUserPreference(Guid userId, List<Guid> terminalIds)
    {
        try
        {
            if (userId != Guid.Empty && terminalIds != null && terminalIds.Count > 0)
                return ResultDto<String>.FailureResult("No Results found for your input request , Please verify the input request");
            else
                return ResultDto<String>.SuccessResult($"Successfully stored user preference for the user {userId} with the terminals {terminalIds}");
        }
        catch (Exception ex)
        {
            return ResultDto<String>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<UserPreferenceOutputDto> GetUserPreference(Guid userId)
    {
        try
        {
            var userList = UserPreferenceHelper.GetUserPreference();
            if (userList.Count == 0)
                throw new NotFoundException("There is error while fetching user list");

            var matchingUser = userList.Where(user => user.UserUid == userId).FirstOrDefault() ?? throw new NotFoundException($"User Not found for selected user {userId}");

            return ResultDto<UserPreferenceOutputDto>.SuccessResult(matchingUser);
        }
        catch (Exception ex)
        {
            return ResultDto<UserPreferenceOutputDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<UserTransactionSummaryDto> GetTransactionSummaries(Guid userId)
    {
        try
        {
            var userList = UserTransactionSummaryHelper.GetTransactionSummary() ?? throw new NotFoundException("There is error while fetching user list");

            var matchingUser = userList.Where(user => user.UserUid == userId).FirstOrDefault() ?? throw new NotFoundException($"User Not found for selected user {userId}");

            return ResultDto<UserTransactionSummaryDto>.SuccessResult(matchingUser);
        }
        catch (Exception ex)
        {
            return ResultDto<UserTransactionSummaryDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<PrestageTransactionOutputDto> CreatePrestageTransaction(Guid userId, Guid TransactionId)
    {
        try
        {
            var prestageTransaction = PrestageTransactionHelper.CreatePrestageTransaction(userId, TransactionId);
            return ResultDto<PrestageTransactionOutputDto>.SuccessResult(prestageTransaction);
        }
        catch (Exception ex)
        {
            return ResultDto<PrestageTransactionOutputDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<List<TransactionSummaryDto>> GetPrestageTransaction(Guid userId)
    {
        try
        {
            var prestageHistory = PrestageHistoryHelper.GetPrestageHistory(userId) ?? throw new NotFoundException("There is error while fetching prestage list");
            return ResultDto<List<TransactionSummaryDto>>.SuccessResult(prestageHistory);
        }
        catch (Exception ex)
        {
            return ResultDto<List<TransactionSummaryDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<List<TransactionSummaryDto>> GetTransactionHistory(Guid userId)
    {
        try
        {
            var prestageHistory = TransactionHistoryHelper.GetTransactionHistory(userId) ?? throw new NotFoundException("There is error while fetching prestage list");
            return ResultDto<List<TransactionSummaryDto>>.SuccessResult(prestageHistory);
        }
        catch (Exception ex)
        {
            return ResultDto<List<TransactionSummaryDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    private static bool IsValidGovernmentNumber(string governmentNumber)
    {
        return governmentNumber.Length >= 5;
    }

    public static bool IsValidDateOfBirth(string dateOfBirth)
    {
        return DateTime.TryParse(dateOfBirth, out DateTime dob) && dob < DateTime.Today;
    }
}
