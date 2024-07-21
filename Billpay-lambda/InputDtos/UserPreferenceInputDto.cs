namespace Billpay_lambda.InputDtos;

public class UserPreferenceInputDto
{
    public Guid UserId { get; set; }
    public List<Guid> TenantIds { get; set; }
}
