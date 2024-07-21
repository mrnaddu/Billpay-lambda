namespace Billpay_lambda.OutputDtos;

public class ProcessBillPayDto
{
    public Guid TerminalId { get; set; }
    public Guid BillerId { get; set; }
    public Guid TransactionId { get; set; }
    public string TransactionStatus { get; set; }
    public string TrnsactionMessage { get; set; }
    public ScreenDataDto ScreenData { get; set; }
}
