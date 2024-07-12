using Billpay_lambda.InputDtos;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Interfaces;

public interface IBillPayservice
{
    public ResultDto<AtmDto> GetTerminal(double lat, double lng);
    public ResultDto<List<BillerInfoDto>> GetBillers(Guid terminalId);
    public ResultDto<ProcessBillPayDto> ProcessBillpay(ProcessBillPayInputDto input);
    public ResultDto<List<BillerInfoDto>> GetTopBillers();
}
