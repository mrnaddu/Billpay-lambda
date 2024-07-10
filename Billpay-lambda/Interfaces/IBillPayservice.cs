using Billpay_lambda.Dtos;

namespace Billpay_lambda.Interfaces;

public interface IBillPayservice
{
    public ResultDto<AtmDto> GetTerminal(double lat, double lng);
    public ResultDto<AtmDto> GetBillers(int terminalId);
}
