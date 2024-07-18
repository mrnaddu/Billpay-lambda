using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public static class UserPreferenceHelper
{
    public static List<UserPreferenceOutputDto> GetUserPreference()
    {
        return userPreference;
    }

    private static readonly List<UserPreferenceOutputDto> userPreference =
    [
        new ()
        {
            Id = 1,
            UserUid = new Guid("f59d8aeb-3c7b-42a1-ae0e-c42b094e6583"),
            UserName = "John Doe",
            Email = "john.doe@example.com",
            Phone = 1234567890,
            Address = "123 Main St, Anytown, USA",
            Terminals =
            [
                new ()
                {
                    Id = new Guid("0c6e6b27-77b1-4b3f-94c3-5d3a6e8c0fe5"),
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
                new ()
                {
                    Id = new Guid("1354a199-69e8-4a7d-9b6a-6a434029b9cc"),
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
                }
            ],
            CreatedDatetime = DateTime.UtcNow,
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "Admin"
        },
        new ()
        {
            Id = 2,
            UserUid = new Guid("00eb826b-e47d-40b7-bf81-45b0c1ba1dfe"),
            UserName = "Jane Smith",
            Email = "jane.smith@example.com",
            Phone = 9876543210,
            Address = "456 Park Ave, Anytown, USA",
            Terminals =
            [
                new ()
                {
                    Id = new Guid("03f7b867-3f3e-4fbb-961a-7fe4c9a9329f"),
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
                }
            ],
            CreatedDatetime = DateTime.UtcNow,
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "Admin"
        }
    ];
}

