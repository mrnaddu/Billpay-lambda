﻿namespace Billpay_lambda.OutputDtos;

public class AuthenticationResultDto
{
    public string AccessToken { get; set; }
    public int ExpiresIn { get; set; }
    public string IdToken { get; set; }
    public string RefreshToken { get; set; }
    public string TokenType { get; set; }
}
