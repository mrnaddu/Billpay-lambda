namespace Billpay_lambda.OutputDtos;

public class TransactionSummaryDto
{
    public int Id { get; set; }
    public Guid TerminalUid { get; set; }
    public Guid PartnerUid { get; set; }
    public Guid MerchantUid { get; set; }
    public Guid SessionUid { get; set; }
    public Guid TransactionReferenceUid { get; set; }
    public string Currency { get; set; }
    public string TransactionType { get; set; }
    public double TransactionAmount { get; set; }
    public double TransactionFee { get; set; }
    public string TransactionStatus { get; set; }
    public string DeliveryOption { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
