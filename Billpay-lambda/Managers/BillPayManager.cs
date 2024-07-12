using Billpay_lambda.Exceptions;
using Billpay_lambda.Helpers;
using Billpay_lambda.InputDtos;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Managers;

public class BillPayManager
{
    public ResultDto<AtmDto> GetNearByTerminal(double lat, double lng)
    {
        try
        {
            var atmList = AtmHelper.GetAllAtms();
            if (atmList.Count == 0)
                throw new NotFoundException("There is error while fetching atm list");

            var matchingAtms = atmList.Where(atm => atm.Lat == lat && atm.Lng == lng).ToList();

            if (matchingAtms.Count == 0)
                throw new NotFoundException($"Terminal Not found for the lattitude: {lat}, longitude: {lng}");

            return ResultDto<AtmDto>.SuccessResult(matchingAtms.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return ResultDto<AtmDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<BillerInfoDto> GetBillersByTerminal(Guid terminalId)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.TerminalId == terminalId).ToList();

            if (matchingBillers.Count == 0)
                throw new NotFoundException($"Biller Not found for selected terminal {terminalId}");

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
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.BillerInfoId == input.BillerId).FirstOrDefault() ?? throw new NotFoundException($"Biller Not found for selected terminal {input.BillerId}");
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
}
