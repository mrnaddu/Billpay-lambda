namespace Billpay_lambda.Dtos;

public class ScreenDataInputDto
{
    public List<DataElementInputDto> DataElement { get; set; }
    public List<ExtraInfoInputDto> ExtraInfo { get; set; }
    public DenominatorDto Denominator { get; set; }
}
