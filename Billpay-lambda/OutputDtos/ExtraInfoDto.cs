namespace Billpay_lambda.OutputDtos;

public class ExtraInfoDto
{
    public List<ExtraDataDto> ExtraData { get; set; }
    public int Denominator { get; set; }
}
