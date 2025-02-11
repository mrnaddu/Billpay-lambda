﻿using System.ComponentModel.DataAnnotations;
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
    [Route("get-nearby-terminals")]
    [SwaggerOperation(Summary = "Get nearby terminal")]
    [ProducesResponseType(typeof(List<AtmDto>), StatusCodes.Status200OK)]
    public IActionResult SearchTerminals([Required] double latitude, [Required] double longitude)
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
    public IActionResult SearchBillers([Required] Guid terminalId)
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
    public IActionResult GetTopBillers([Required] Guid terminalId)
    {
        var result = billPayservice.GetTopBillers(terminalId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-biller")]
    [SwaggerOperation(Summary = "Get biller")]
    [ProducesResponseType(typeof(BillerInfoDto), StatusCodes.Status200OK)]
    public IActionResult GetBiller([Required] Guid billerId)
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
    public IActionResult ProcessBillpay([FromHeader][Required] Guid terminalId, [FromHeader][Required] Guid billerId, ProcessBillPayInputDto input)
    {
        var result = billPayservice.ProcessBillpay(terminalId, billerId, input);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-biller-category")]
    [SwaggerOperation(Summary = "Get biller category")]
    [ProducesResponseType(typeof(List<BillerInfoDto>), StatusCodes.Status200OK)]
    public IActionResult GetBillerCategory([Required] Guid terminalId)
    {
        var result = billPayservice.GetBillerCategory(terminalId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpPost]
    [Route("store-user-preference")]
    [SwaggerOperation(Summary = "Store user preference")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult StoreUserPreference(UserPreferenceInputDto input)
    {
        var result = billPayservice.StoreUserPreference(input);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-user-preference")]
    [SwaggerOperation(Summary = "Get user preference")]
    [ProducesResponseType(typeof(UserPreferenceOutputDto), StatusCodes.Status200OK)]
    public IActionResult GetUserPreference([Required] Guid userId)
    {
        var result = billPayservice.GetUserPreference(userId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-transaction-summary")]
    [SwaggerOperation(Summary = "Get transaction summary")]
    [ProducesResponseType(typeof(UserTransactionSummaryDto), StatusCodes.Status200OK)]
    public IActionResult GetTransactionSummary([Required] Guid userId)
    {
        var result = billPayservice.GetTransactionSummaries(userId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpPost]
    [Route("create-prestage-transaction")]
    [SwaggerOperation(Summary = "Create prestage transaction")]
    [ProducesResponseType(typeof(PrestageTransactionOutputDto), StatusCodes.Status200OK)]
    public IActionResult PrestageTransaction([Required] Guid userId, [Required] Guid transactionId)
    {
        var result = billPayservice.PrestageTransaction(userId, transactionId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-prestage-transaction")]
    [SwaggerOperation(Summary = "Get prestage transaction")]
    [ProducesResponseType(typeof(List<TransactionSummaryDto>), StatusCodes.Status200OK)]
    public IActionResult GetPrestageTransaction([Required] Guid userId)
    {
        var result = billPayservice.GetPrestageTransaction(userId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }

    [HttpGet]
    [Route("get-transaction-history")]
    [SwaggerOperation(Summary = "Get prestage transaction")]
    [ProducesResponseType(typeof(List<TransactionSummaryDto>), StatusCodes.Status200OK)]
    public IActionResult GetTransactionHistory([Required] Guid userId)
    {
        var result = billPayservice.GetTransactionHistory(userId);
        if (result.Success)
            return Ok(result);
        else
            return StatusCode(500, new { ErrorMessage = result.Message });
    }
}
