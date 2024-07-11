using Billpay_lambda.Dtos;
using Billpay_lambda.Exceptions;
using Billpay_lambda.Helpers;

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
}
