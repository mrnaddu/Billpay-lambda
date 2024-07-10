﻿using Billpay_lambda.Dtos;
using Billpay_lambda.Interfaces;
using dev_lambda_billpay;
using Microsoft.AspNetCore.Mvc;

namespace Billpay_lambda.Controllers;

[Route("api/[controller]")]
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
    [Route("GetNearbyATM")]
    public Task<Result<List<AtmDto>>> SearchTerminals(double lat, double lng)
    {
        logger.LogInformation("Handling the 'Get' Request for search-terminals");

        logger.LogInformation($"Get Nearby atm based on lattitude : {lat} and longitude : {lng}");

        var atmList = new List<AtmDto>
{
    new() {
        TermId = "T000000013",
        TermNo = "D0000003",
        Lat = 37.486,
        Lng = 127.1028,
        AgentId = "30014943",
        AgentSequence = "36",
        Location = "211-2 Suseo-dong, Gangnam District, Seoul, South Korea",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2359",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2359",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2359",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2359",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2359",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2359",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2359",
        PartnerCd = "2",
        AvailableTransaction = true,
        CancelCapability = true
    },
    new() {
        TermId = "T000000027",
        TermNo = "HQ0001",
        Lat = 37.4880028,
        Lng = 127.1026639,
        AgentId = null,
        AgentSequence = null,
        Location = "281 Gwangpyeong-ro, Gangnam-gu, Seoul",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2359",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2359",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2359",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2359",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2359",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2359",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2359",
        PartnerCd = "2",
        AvailableTransaction = true,
        CancelCapability = true
    },
    new ()
    {
        TermId = "T000000011",
        TermNo = "D0000002",
        Lat = 37.488456,
        Lng = 127.10419,
        AgentId = null,
        AgentSequence = null,
        Location = "South Korea, street address Seogwan-dong KR #1512, 716 Suseo-dong, Gangnam-gu, Seoul",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2359",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2359",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2359",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2359",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2359",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2359",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2359",
        PartnerCd = "2",
        AvailableTransaction = true,
        CancelCapability = false
    },
    new() {
        TermId = "T000000036",
        TermNo = "JULIE_LAPTOP",
        Lat = 37.4889719,
        Lng = 127.1053398,
        AgentId = "40081681",
        AgentSequence = "20",
        Location = "52 Bamgogae-ro 1-gil, Gangnam District, Seoul, South Korea",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2359",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2359",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2359",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2359",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2359",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2359",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2359",
        PartnerCd = "2",
        AvailableTransaction = true,
        CancelCapability = true
    },
    new() {
        TermId = "T000000001",
        TermNo = "D0000001",
        Lat = 37.4982444,
        Lng = 127.1021918,
        AgentId = null,
        AgentSequence = null,
        Location = "909 Garak-dong, Songpa District, Seoul, South Korea",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2359",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2359",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2359",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2359",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2359",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2359",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2359",
        PartnerCd = "2",
        AvailableTransaction = true,
        CancelCapability = false
    },
    new() {
        TermId = "T000000023",
        TermNo = "D0000004",
        Lat = 37.45002,
        Lng = 127.102555,
        AgentId = null,
        AgentSequence = null,
        Location = "seoul",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2259",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2259",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2259",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2259",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2259",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2259",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2259",
        PartnerCd = "1",
        AvailableTransaction = false,
        CancelCapability = false
    },
    new() {
        TermId = "T000000049",
        TermNo = "D0000011",
        Lat = 37.4996077,
        Lng = 127.0356518,
        AgentId = "40081681",
        AgentSequence = "20",
        Location = "Seoul, South Korea",
        PostalCd = null,
        WorkSunFlag = "1",
        WorkSunStartTime = "0000",
        WorkSunEndTime = "2359",
        WorkMonFlag = "1",
        WorkMonStartTime = "0000",
        WorkMonEndTime = "2359",
        WorkTueFlag = "1",
        WorkTueStartTime = "0000",
        WorkTueEndTime = "2359",
        WorkWebFlag = "1",
        WorkWebStartTime = "0000",
        WorkWebEndTime = "2359",
        WorkThuFlag = "1",
        WorkThuStartTime = "0000",
        WorkThuEndTime = "2359",
        WorkFriFlag = "1",
        WorkFriStartTime = "0000",
        WorkFriEndTime = "2359",
        WorkSatFlag = "1",
        WorkSatStartTime = "0000",
        WorkSatEndTime = "2359",
        PartnerCd = "2",
        AvailableTransaction = true,
        CancelCapability = true
    }
};

        var result = new Result<List<AtmDto>>
        {
            IsSuccess = true,
            Data = atmList
        };

        return Task.FromResult(result);
    }

    [HttpGet]
    [Route("GetTopBillers")]
    public string TopBillers()
    {
        logger.LogInformation("Handling the 'Get' Request for top-billers");

        return "This is list of top billers";
    }

    [HttpGet]
    [Route("GetBillerCategory")]
    public string BillersCategory()
    {
        logger.LogInformation("Handling the 'Get' Request for billers-category");

        return "This is list of top billers category";
    }

    [HttpPost]
    [Route("ProcessBillpay")]
    public string ProcessBillpay()
    {
        logger.LogInformation("Handling the 'Post' Request for process-billpay");

        return "This is list of process billpay";
    }
}
