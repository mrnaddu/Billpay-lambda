using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Billpay_lambda.Interfaces;

namespace Billpay_lambda.Services;

public class CognitoService : ICognitoService
{
    private readonly IAmazonCognitoIdentityProvider cognitoClient;
    private readonly string userPoolId;
    private readonly string clientId;
    public CognitoService(string awsAccessKeyId, string awsSecretAccessKey, string regionEndpoint, string userPoolId, string clientId)
    {
        cognitoClient = new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey), RegionEndpoint.GetBySystemName(regionEndpoint));
        this.userPoolId = userPoolId;
        this.clientId = clientId;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        InitiateAuthRequest authRequest = new()
        {
            AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
            ClientId = clientId,
            AuthParameters = new Dictionary<string, string>
            {
                { "USERNAME", username },
                { "PASSWORD", password }
            }
        };

        var authResponse = await cognitoClient.InitiateAuthAsync(authRequest);

        return authResponse.AuthenticationResult.IdToken;
    }
}
