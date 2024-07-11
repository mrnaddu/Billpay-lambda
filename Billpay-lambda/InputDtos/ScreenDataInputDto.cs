namespace Billpay_lambda.InputDtos;

public class ScreenDataInputDto
{
    public List<DataElementInputDto> DataElements { get; set; }
    public int ScreenId { get; set; }
}
