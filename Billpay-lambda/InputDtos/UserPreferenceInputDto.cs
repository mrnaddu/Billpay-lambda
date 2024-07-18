namespace Billpay_lambda.InputDtos;

public class UserPreferenceInputDto
{
    public Guid UserInoId { get; set; }
    public List<Guid> TenantIds { get; set; }
}
