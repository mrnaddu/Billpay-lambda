namespace Billpay_lambda.OutputDtos;

public class DataElementDto
{
    public string Id { get; set; }
    public string Label { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNumber { get; set; }
    public string ElementType { get; set; }
    public string WaterMark { get; set; }
    public int MaxLength { get; set; }
    public int MinLength { get; set; }
    public List<NotificationDto> Notification { get; set; }
    public ExtraInfoDto ExtraInfo { get; set; }
}
