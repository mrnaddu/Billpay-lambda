namespace Billpay_lambda.Models;

public class CognitoAuthRequest
{
    public AuthParameters AuthParameters { get; set; }
    public string AuthFlow { get; set; }
    public string ClientId { get; set; }
}
