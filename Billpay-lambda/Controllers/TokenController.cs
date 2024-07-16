using System.ComponentModel.DataAnnotations;
using Billpay_lambda.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billpay_lambda.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ITokenService tokenService;
    public TokenController(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }

    [HttpGet]
    [Route("get-client-token")]
    public IActionResult GetClientToken([Required] string clientId, [Required] string clientSecret)
    {
        var result = tokenService.GetClientToken(clientId, clientSecret);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-user-token")]
    public IActionResult GetUserToken()
    {
        var result = tokenService.GetUserAccessToken();
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }
}
