namespace Billpay_lambda.Interfaces;

public interface ICognitoService
{
    Task<string> AuthenticateAsync(string username, string password);
}
