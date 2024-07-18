namespace Billpay_lambda.OutputDtos;

public class IndustryDto
{
    public int Id { get; set; }
    public string IndustryName { get; set; }
    public int IndustryCode { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
