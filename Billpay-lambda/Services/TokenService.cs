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
        var request = new HttpRequestMessage(HttpMethod.Post, TokenConst.url);
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
}
