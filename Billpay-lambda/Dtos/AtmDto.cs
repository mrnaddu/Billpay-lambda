namespace Billpay_lambda.Dtos;

public class AtmDto
{
    public Guid Id { get; set; }
    public string TermId { get; set; }
    public string TermNo { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string AgentId { get; set; }
    public string AgentSequence { get; set; }
    public string Location { get; set; }
    public string PostalCd { get; set; }
    public string WorkSunFlag { get; set; }
    public string WorkSunStartTime { get; set; }
    public string WorkSunEndTime { get; set; }
    public string WorkMonFlag { get; set; }
    public string WorkMonStartTime { get; set; }
    public string WorkMonEndTime { get; set; }
    public string WorkTueFlag { get; set; }
    public string WorkTueStartTime { get; set; }
    public string WorkTueEndTime { get; set; }
    public string WorkWebFlag { get; set; }
    public string WorkWebStartTime { get; set; }
    public string WorkWebEndTime { get; set; }
    public string WorkThuFlag { get; set; }
    public string WorkThuStartTime { get; set; }
    public string WorkThuEndTime { get; set; }
    public string WorkFriFlag { get; set; }
    public string WorkFriStartTime { get; set; }
    public string WorkFriEndTime { get; set; }
    public string WorkSatFlag { get; set; }
    public string WorkSatStartTime { get; set; }
    public string WorkSatEndTime { get; set; }
    public string PartnerCd { get; set; }
    public bool AvailableTransaction { get; set; }
    public bool CancelCapability { get; set; }
}
