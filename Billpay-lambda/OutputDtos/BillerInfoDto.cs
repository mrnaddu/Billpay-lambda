using System.Text.Json;

namespace Billpay_lambda.OutputDtos;

public class BillerInfoDto
{
    public int Id { get; set; }
    public Guid BillerInfoUid { get; set; }
    public Guid PartnerIdUid { get; set; }
    public Guid ReferenceBillerUid { get; set; }
    public Guid ReferenceTerminalUid { get; set; }
    public JsonElement BillChoice { get; set; }
    public string BillerName { get; set; }
    public bool IsExtraData { get; set; }
    public bool IsCompilance { get; set; }
    public int MaxStubs { get; set; }
    public JsonElement PaymentTypes { get; set; }
    public List<IndustryDto> Industries { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
