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
                throw new NotFoundException();

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
}
