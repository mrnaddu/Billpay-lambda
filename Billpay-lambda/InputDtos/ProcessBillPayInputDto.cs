namespace Billpay_lambda.InputDtos;

public class ProcessBillPayInputDto
{
    public Guid TransactionId { get; set; }
    public ScreenDataInputDto ScreenData { get; set; }
}
