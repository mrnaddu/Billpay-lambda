namespace Billpay_lambda.Dtos;

public class ExtraInfoDto
{
    public Guid Id { get; set; }
    public string Label { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNumber { get; set; }
    public string ElementType { get; set; }
    public int MaxLength { get; set; }
    public List<NotificationDto> Notification { get; set; }
}
