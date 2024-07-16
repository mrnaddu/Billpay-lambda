using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Billpay_lambda.Helpers;

public class CognitoSigningKeyHelper
{
    private readonly string _userPoolClientSecret;
    public CognitoSigningKeyHelper(string userPoolClientSecret)
    {
        _userPoolClientSecret = userPoolClientSecret;
    }
    public SymmetricSecurityKey ComputeKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_userPoolClientSecret));
    }
}
