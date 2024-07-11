namespace Billpay_lambda.Dtos;

public class ScreenDataDto
{
    public List<DataElementDto> DataElement { get; set; }
    public List<ExtraInfoDto> ExtraInfo { get; set; }
    public DenominatorDto Denominator { get; set; }
}
