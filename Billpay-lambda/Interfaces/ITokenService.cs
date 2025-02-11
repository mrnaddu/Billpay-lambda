﻿using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Interfaces;

public interface ITokenService
{
    ResultDto<string> GetClientToken(string clientId, string clientSecret);
    ResultDto<AuthenticationResultDto> GetUserAccessToken(string userName, string password);
}
