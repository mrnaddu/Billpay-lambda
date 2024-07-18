using System.ComponentModel.DataAnnotations;
using Billpay_lambda.InputDtos;
using Billpay_lambda.Interfaces;
using Billpay_lambda.OutputDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Billpay_lambda.Controllers;

[Route("api/bill-pay")]
[ApiController]
[Authorize]
public class BillPayController : ControllerBase
{
    private readonly IBillPayservice billPayservice;
    public BillPayController(IBillPayservice billPayservice)
    {
        this.billPayservice = billPayservice;
    }

    [HttpGet]
    [Route("get-nearby-terminal")]
    [SwaggerOperation(Summary = "Get nearby terminal")]
    [ProducesResponseType(typeof(List<AtmDto>), StatusCodes.Status200OK)]
    public IActionResult SearchTerminal([Required] double latitude, [Required] double longitude)
    {
        var result = billPayservice.GetTerminal(latitude, longitude);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("search-billers")]
    [SwaggerOperation(Summary = "Search billers")]
    [ProducesResponseType(typeof(List<BillerInfoDto>), StatusCodes.Status200OK)]
    public IActionResult SearchBiller(Guid terminalId)
    {
        var result = billPayservice.GetAllBillers(terminalId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-top-billers")]
    [SwaggerOperation(Summary = "Get top billers")]
    [ProducesResponseType(typeof(List<BillerInfoDto>), StatusCodes.Status200OK)]
    public IActionResult TopBillers()
    {
        var result = billPayservice.GetTopBillers();
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-billers-category")]
    [SwaggerOperation(Summary = "Get billers category")]
    [ProducesResponseType(typeof(List<BillerInfoDto>), StatusCodes.Status200OK)]
    public string BillersCategory()
    {
        return "This is list of top billers category";
    }

    [HttpGet]
    [Route("get-biller")]
    [SwaggerOperation(Summary = "Get biller")]
    [ProducesResponseType(typeof(BillerInfoDto), StatusCodes.Status200OK)]
    public IActionResult GetBiller(Guid billerId)
    {
        var result = billPayservice.GetBiller(billerId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpPost]
    [Route("process-billpay")]
    [SwaggerOperation(Summary = "Process billpay")]
    [ProducesResponseType(typeof(List<BillerInfoDto>), StatusCodes.Status200OK)]
    public IActionResult ProcessBillpay(ProcessBillPayInputDto request)
    {
        var result = billPayservice.ProcessBillpay(request);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }
}
