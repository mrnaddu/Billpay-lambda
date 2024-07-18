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

            var matchingAtms = atmList.Where(atm => atm.Lat == lat && atm.Lng == lng).ToList();

            if (matchingAtms.Count == 0)
                throw new NotFoundException($"Terminal Not found for the lattitude: {lat}, longitude: {lng}");

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

            var matchingBillers = billerList.Where(biller => biller.ReferenceTerminalUid == terminalId).ToList();

            if (matchingBillers.Count == 0)
                throw new NotFoundException($"Biller Not found for selected terminal {terminalId}");

            return ResultDto<List<BillerInfoDto>>.SuccessResult(matchingBillers);
        }
        catch (Exception ex)
        {
            return ResultDto<List<BillerInfoDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<List<BillerInfoDto>> GetTopBillers()
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

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

            var matchingBillers = billerList.Where(biller => biller.ReferenceBillerUid == billerId).ToList();

            if (matchingBillers.Count == 0)
                throw new NotFoundException($"Biller Not found {billerId}");

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
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

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

    public ResultDto<List<BillerInfoDto>> GetBillerCategory(string category)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller category list");

            var matchingCategory = billerList.Where(biller => biller.Industries.Any(industry => industry.IndustryName == category)).ToList();
            return ResultDto<List<BillerInfoDto>>.SuccessResult(matchingCategory);
        }
        catch (Exception ex)
        {
            return ResultDto<List<BillerInfoDto>>.FailureResult($"Exception: {ex.Message}");
        }
    }
}
