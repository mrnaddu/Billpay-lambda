namespace Billpay_lambda.Consts;

public static class TokenConst
{
    public const string client_url = "https://billpay-webapi.auth.us-east-1.amazoncognito.com/oauth2/token";
    public const string client_grantType = "client_credentials";
    public const string user_access_token_url = "https://cognito-idp.us-east-1.amazonaws.com/";
    public const string auth_flow = "USER_PASSWORD_AUTH";
    public const string client_id = "6t8lnsgp85b13ptq3071ojituf";
    public const string amz_target = "AWSCognitoIdentityProviderService.InitiateAuth";
}
