namespace Billpay_lambda.Dtos;

public class ProcessBillPayDto
{
    public Guid TerminalId { get; set; }
    public Guid BillerId { get; set; }
    public Guid TransactionId { get; set; }
    public ScreenDataDto ScreenData { get; set; }
}
