namespace Billpay_lambda.Dtos;

public class ProcessBillPayInputDto
{
    public Guid TerminalId { get; set; }
    public Guid BillerId { get; set; }
    public Guid TransactionId { get; set; }
    public ScreenDataDto ScreenData { get; set; }
}
