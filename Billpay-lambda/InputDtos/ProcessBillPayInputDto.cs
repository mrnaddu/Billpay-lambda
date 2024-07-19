namespace Billpay_lambda.InputDtos;

public class ProcessBillPayInputDto
{
    public Guid TransactionId { get; set; } = Guid.Empty;
    public bool IsTransactionSummary { get; set; } = false;
    public ScreenDataInputDto ScreenData { get; set; }
}
