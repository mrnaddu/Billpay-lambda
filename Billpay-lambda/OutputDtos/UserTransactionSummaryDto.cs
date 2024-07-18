namespace Billpay_lambda.OutputDtos;

public class UserTransactionSummaryDto
{
    public int Id { get; set; }
    public Guid UserUid { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }
    public List<TransactionSummaryDto> TransactionSummaries { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
