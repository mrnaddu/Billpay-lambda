namespace Billpay_lambda.Dtos;

public class ScreenDataDto
{
    public List<DataElementInputDto> DataElement { get; set; }
    public List<ExtraInfoInputDto> ExtraInfo { get; set; }
    public int Denominator { get; set; }
}
