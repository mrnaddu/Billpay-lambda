using Billpay_lambda.Consts;
using Billpay_lambda.Interfaces;
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

    public ResultDto<string> GetUserAccessToken()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://cognito-idp.us-east-1.amazonaws.com/");
        request.Headers.Add("X-Amz-Target", "AWSCognitoIdentityProviderService.InitiateAuth");
        var content = new StringContent("{\r\n    \"AuthParameters\" : {\r\n        \"USERNAME\" : \"e4684468-3021-70e1-276a-ed00c6ab0498\",\r\n        \"PASSWORD\" : \"Raasoft@8310\"\r\n    },\r\n    \"AuthFlow\" : \"USER_PASSWORD_AUTH\",\r\n    \"ClientId\" : \"6t8lnsgp85b13ptq3071ojituf\"\r\n}", null, "application/x-amz-json-1.1");
        request.Content = content;
        var response = client.Send(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        return ResultDto<string>.SuccessResult("");

    }
}
