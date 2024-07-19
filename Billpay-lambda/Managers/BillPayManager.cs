﻿using Billpay_lambda.Exceptions;
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

    public ResultDto<ProcessBillPayDto> ProcessBillpayDetails(ProcessBillPayInputDto input)
    {
        try
        {
            if (input.IsTransactionSummary == true)
            {
                var transactionSummary = ProcessBillPayHelper.GetTransactionSummary();
                return ResultDto<ProcessBillPayDto>.SuccessResult(transactionSummary);
            }
            var billerList = BillerHelper.GetAllBillers() ?? throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.ReferenceBillerUid == input.BillerId).FirstOrDefault() ?? throw new NotFoundException($"Biller Not found for selected terminal {input.BillerId}");
            if (matchingBillers.IsExtraData == false)
            {
                var withoutExtraData = ProcessBillPayHelper.GetWithoutExtraData();
                return ResultDto<ProcessBillPayDto>.SuccessResult(withoutExtraData);
            }
            else if (matchingBillers.IsCompilance == true)
            {
                var compilance = ProcessBillPayHelper.GetCompilance();
                return ResultDto<ProcessBillPayDto>.SuccessResult(compilance);
            }
            else
            {
                var withData = ProcessBillPayHelper.GetWitExtraData();
                return ResultDto<ProcessBillPayDto>.SuccessResult(withData);
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
}
