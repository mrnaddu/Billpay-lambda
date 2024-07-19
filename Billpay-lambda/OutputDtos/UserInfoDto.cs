namespace Billpay_lambda.OutputDtos;

public class UserInfoDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Otc { get; set; }
    public DateTime OtcExpiryDateTime { get; set; }
    public string TransactionSatus { get; set; }

}
