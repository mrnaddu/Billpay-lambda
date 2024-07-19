namespace Billpay_lambda.OutputDtos;

public class TransactionSummaryDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TransactionId { get; set; }
    public Guid TerminalId { get; set; }
    public Guid PartnerId { get; set; }
    public Guid SessionId { get; set; }
    public Guid TransactionReferenceId { get; set; }
    public string Currency { get; set; }
    public string TransactionProvisioner { get; set; }
    public string TransactionType { get; set; }
    public double TransactionAmount { get; set; }
    public double TransactionFee { get; set; }
    public string TransactionStatus { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
