namespace Billpay_lambda.Interfaces;

public interface ITokenService
{
    Task<string> GetClientToken(string clientId, string clientSecret);
}
