using Billpay_lambda.InputDtos;
using Billpay_lambda.Interfaces;
using Billpay_lambda.Managers;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Services;

public class BillPayservice : IBillPayservice
{
    private readonly BillPayManager billPayManager;
    public BillPayservice(BillPayManager billPayManager)
    {
        this.billPayManager = billPayManager;
    }

    public ResultDto<List<BillerInfoDto>> GetBillers(Guid terminalId)
    {
        var result = billPayManager.GetBillersByTerminal(terminalId);
        if (result.Success)
            return ResultDto<List<BillerInfoDto>>.SuccessResult(result.Data);

        return ResultDto<List<BillerInfoDto>>.FailureResult(result.Message);
    }

    public ResultDto<AtmDto> GetTerminal(double lat, double lng)
    {
        var result = billPayManager.GetNearByTerminal(lat, lng);
        if (result.Success)
            return ResultDto<AtmDto>.SuccessResult(result.Data);

        return ResultDto<AtmDto>.FailureResult(result.Message);
    }

    public ResultDto<List<BillerInfoDto>> GetTopBillers()
    {
        throw new NotImplementedException();
    }

    public ResultDto<ProcessBillPayDto> ProcessBillpay(ProcessBillPayInputDto input)
    {
        var result = billPayManager.ProcessBillpayDetails(input);
        if (result.Success)
            return ResultDto<ProcessBillPayDto>.SuccessResult(result.Data);

        return ResultDto<ProcessBillPayDto>.FailureResult(result.Message);
    }
}
