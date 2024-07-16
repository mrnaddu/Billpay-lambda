using Amazon.AspNetCore.Identity.Cognito.Extensions;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Billpay_lambda.Helpers;
using Billpay_lambda.InputDtos;
using Microsoft.AspNetCore.Mvc;

namespace Billpay_lambda.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokensController : ControllerBase
{
    private readonly IAmazonCognitoIdentityProvider _identityProvider;
    private readonly AWSCognitoClientOptions _options;
    private readonly CognitoClientSecretHelper _clientSecret;

    public TokensController(
        IAmazonCognitoIdentityProvider identityProvider,
        AWSCognitoClientOptions options,
        CognitoClientSecretHelper clientSecret)
    {
        _identityProvider = identityProvider ?? throw new ArgumentNullException(nameof(identityProvider));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
    }

    [HttpPost]
    public async Task<ActionResult<string>> GetAsync(TokenCredentialDto credential)
    {
        var request = new AdminInitiateAuthRequest
        {
            ClientId = _options.UserPoolClientId,
            UserPoolId = _options.UserPoolId,
            AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
        };

        // For ADMIN_NO_SRP_AUTH: USERNAME (required), SECRET_HASH (if app client is configured
        // with client secret), PASSWORD (required)
        request.AuthParameters.Add("USERNAME", credential.Email);
        request.AuthParameters.Add("PASSWORD", credential.Password);
        request.AuthParameters.Add("SECRET_HASH", _clientSecret.ComputeHash(credential.Email));

        string accessToken;

        try
        {
            var response = await _identityProvider.AdminInitiateAuthAsync(request);
            accessToken = response.AuthenticationResult.AccessToken;
        }
        catch (UserNotFoundException)
        {
            ModelState.AddModelError("UserNotFound", $"A user having email '{credential.Email}' does not exist.");
            return BadRequest(ModelState);
        }

        return accessToken;
    }

    // email : billpay.test@gmail.com , pass : 8310@NnNn
    // url https://billpay-webapi.auth.us-east-1.amazoncognito.com

}
