using System.ComponentModel.DataAnnotations;

namespace Billpay_lambda.InputDtos;

public class ProcessBillPayInputDto
{
    public Guid TerminalId { get; set; }
    [Required]
    public Guid BillerId { get; set; }
    public Guid TransactionId { get; set; }
    public bool IsTransactionSummary { get; set; }
    public ScreenDataInputDto ScreenData { get; set; }
}
