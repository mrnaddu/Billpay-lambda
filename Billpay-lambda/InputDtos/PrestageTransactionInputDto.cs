namespace Billpay_lambda.InputDtos;

public class PrestageTransactionInputDto
{
    public Guid UserId { get; set; }
    public Guid TransactionId { get; set; }
}
