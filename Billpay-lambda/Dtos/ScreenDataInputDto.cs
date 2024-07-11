namespace Billpay_lambda.Dtos;

public class ScreenDataInputDto
{
    public List<DataElementDto> DataElements { get; set; }
    public ExtraInfoDto ExtraInfo { get; set; }
}
