﻿using System.Text.Json;

namespace Billpay_lambda.OutputDtos;

public class BillerInfoDto
{
    public int Id { get; set; }
    public Guid BillerInfoId { get; set; }
    public Guid PartnerId { get; set; }
    public Guid BillerId { get; set; }
    public Guid MerchantId { get; set; }
    public JsonElement BillChoice { get; set; }
    public string BillerName { get; set; }
    public bool IsExtraData { get; set; }
    public bool IsCompilance { get; set; }
    public int MaxStubs { get; set; }
    public JsonElement PaymentTypes { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
