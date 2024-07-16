using Billpay_lambda.Interfaces;

namespace Billpay_lambda.Services;

public class TokenService : ITokenService
{
    public Task<string> GetClientToken(string clientId, string clientSecret)
    {
        throw new NotImplementedException();
    }
}
