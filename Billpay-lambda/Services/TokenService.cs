using Billpay_lambda.Consts;
using Billpay_lambda.Interfaces;
using Billpay_lambda.Models;
using Billpay_lambda.OutputDtos;
using Newtonsoft.Json;

namespace Billpay_lambda.Services;

public class TokenService : ITokenService
{
    public ResultDto<string> GetClientToken(string clientId, string clientSecret)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, TokenConst.client_url);
        var collection = new List<KeyValuePair<string, string>>
        {
            new("grant_type", TokenConst.client_grantType),
            new("client_id", clientId), // 35i150ubtv7hkarmqeh4oeimff
            new("client_secret", clientSecret) // 9qah5atokl89rcug38flr6mg869thi0t1tte5rk0sb5psamenn6
        };
        var content = new FormUrlEncodedContent(collection);
        request.Content = content;
        var response = client.Send(request);
        if (!response.IsSuccessStatusCode)
            return ResultDto<string>.FailureResult("Token Not Be Generated");
        else
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
            string accessToken = jsonResponse.access_token;
            return ResultDto<string>.SuccessResult(accessToken);
        }
    }

    public ResultDto<AuthenticationResultDto> GetUserAccessToken(string userName, string password)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, TokenConst.user_access_token_url);
        request.Headers.Add("X-Amz-Target", TokenConst.amz_target);
        AuthParameters authParams = new()
        {
            USERNAME = userName, // e4684468-3021-70e1-276a-ed00c6ab0498
            PASSWORD = password // Raasoft@8310
        };

        CognitoAuthRequest authRequest = new()
        {
            AuthParameters = authParams,
            AuthFlow = TokenConst.auth_flow,
            ClientId = TokenConst.client_id
        };

        string json = JsonConvert.SerializeObject(authRequest);
        var content = new StringContent(json, null, "application/x-amz-json-1.1");
        request.Content = content;
        var response = client.Send(request);
        response.EnsureSuccessStatusCode();

        if (!response.IsSuccessStatusCode)
            return ResultDto<AuthenticationResultDto>.FailureResult("Token Not Be Generated");
        else
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
            var result = new AuthenticationResultDto()
            {
                AccessToken = jsonResponse.AuthenticationResult.AccessToken,
                IdToken = jsonResponse.AuthenticationResult.IdToken,
                RefreshToken = jsonResponse.AuthenticationResult.RefreshToken,
                ExpiresIn = jsonResponse.AuthenticationResult.ExpiresIn,
                TokenType = jsonResponse.AuthenticationResult.TokenType
            };
            return ResultDto<AuthenticationResultDto>.SuccessResult(result);
        }
    }
}
