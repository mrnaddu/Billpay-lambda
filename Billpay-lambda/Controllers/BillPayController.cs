using System.ComponentModel.DataAnnotations;
using Billpay_lambda.InputDtos;
using Billpay_lambda.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billpay_lambda.Controllers;

[Route("api/bill-pay")]
[ApiController]
public class BillPayController : ControllerBase
{
    private readonly IBillPayservice billPayservice;
    public BillPayController(IBillPayservice billPayservice)
    {
        this.billPayservice = billPayservice;
    }

    [HttpGet]
    [Route("get-nearby-terminal")]
    public IActionResult SearchTerminal([Required] double latitude, [Required] double longitude)
    {
        var result = billPayservice.GetTerminal(latitude, longitude);
        if (result.Success)
            return Ok(result.Data);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("search-biller")]
    public IActionResult SearchBiller(Guid terminalId)
    {
        var result = billPayservice.GetAllBillers(terminalId);
        if (result.Success)
            return Ok(result.Data);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-top-billers")]
    public IActionResult TopBillers()
    {
        var result = billPayservice.GetTopBillers();
        if (result.Success)
            return Ok(result.Data);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-billers-category")]
    public string BillersCategory()
    {
        return "This is list of top billers category";
    }

    [HttpGet]
    [Route("get-biller")]
    public IActionResult GetBiller(Guid billerId)
    {
        var result = billPayservice.GetBiller(billerId);
        if (result.Success)
            return Ok(result.Data);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpPost]
    [Route("process-billpay")]
    public IActionResult ProcessBillpay(ProcessBillPayInputDto request)
    {
        var result = billPayservice.ProcessBillpay(request);
        if (result.Success)
            return Ok(result.Data);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }
}
