using Billpay_lambda.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billpay_lambda.Controllers;

[Route("api/bill-pay")]
[ApiController]
public class BillPayController : ControllerBase
{
    private readonly ILogger<BillPayController> logger;
    private readonly IBillPayservice billPayservice;
    public BillPayController(
        ILogger<BillPayController> logger,
        IBillPayservice billPayservice)
    {
        this.logger = logger;
        this.billPayservice = billPayservice;
    }

    [HttpGet]
    [Route("get-nearby-terminal")]
    public IActionResult SearchTerminals(double lat, double lng)
    {
        var result = billPayservice.GetTerminal(lat, lng);

        if (result.Success)
            return Ok(result.Data);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-top-billers")]
    public string TopBillers()
    {
        logger.LogInformation("Handling the 'Get' Request for top-billers");

        return "This is list of top billers";
    }

    [HttpGet]
    [Route("get-billers-category")]
    public string BillersCategory()
    {
        logger.LogInformation("Handling the 'Get' Request for billers-category");

        return "This is list of top billers category";
    }

    [HttpPost]
    [Route("process-billpay")]
    public string ProcessBillpay()
    {
        logger.LogInformation("Handling the 'Post' Request for process-billpay");

        return "This is list of process billpay";
    }
}
