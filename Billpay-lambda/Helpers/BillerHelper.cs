using System.Text.Json;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public static class BillerHelper
{
    public static List<BillerInfoDto> GetAllBillers()
    {
        return billerInfoList;
    }

    private static readonly List<BillerInfoDto> billerInfoList =
    [
        new ()
        {
            Id = 1,
            BillerInfoUid = new Guid("03f7b867-3f3e-4fbb-961a-7fe4c9a9329f"),
            PartnerIdUid = new Guid("e8b6c62a-69b8-48c7-88f4-91f98272b694"),
            ReferenceBillerUid = new Guid("0c6e6b27-77b1-4b3f-94c3-5d3a6e8c0fe5"),
            ReferenceTerminalUid = new Guid("d19752e5-b3f6-49c8-a240-a32dc70f635c"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option A\"}").RootElement,
            BillerName = "Sample Biller Inc. A",
            IsExtraData = false,
            IsCompilance = true,
            MaxStubs = 5,
            PaymentTypes = JsonDocument.Parse("[\"Credit Card\", \"Bank Transfer\"]").RootElement,
            Industries = [
                new ()
                {
                    Id = 1,
                    IndustryName = "Water",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                },
                new ()
                {
                    Id = 2,
                    IndustryName = "Mobile",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                }
            ],
            CreatedDatetime = DateTime.UtcNow.AddDays(-7),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        },
        new ()
        {
            Id = 2,
            BillerInfoUid = new Guid("d6b2e4a2-6c7f-493b-b12f-9d1d8fe1f3e3"),
            PartnerIdUid = new Guid("f1a42f3c-83d7-4a62-8baa-3c524fd45e1b"),
            ReferenceBillerUid = new Guid("be82a1a5-4e47-4b16-92a1-01a419f3e15c"),
            ReferenceTerminalUid = new Guid("d19752e5-b3f6-49c8-a240-a32dc70f635c"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option B\"}").RootElement,
            BillerName = "Sample Biller Inc. B",
            IsExtraData = false,
            IsCompilance = false,
            MaxStubs = 3,
            PaymentTypes = JsonDocument.Parse("[\"Debit Card\", \"PayPal\"]").RootElement,
            Industries = [
                new ()
                {
                    Id = 1,
                    IndustryName = "Gas",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                },
                new ()
                {
                    Id = 2,
                    IndustryName = "Electricity",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                }
            ],
            CreatedDatetime = DateTime.UtcNow.AddDays(-10),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        },
        new ()
        {
            Id = 3,
            BillerInfoUid = new Guid("837f1232-b632-45d3-badf-68d5f9e9d6e1"),
            PartnerIdUid = new Guid("a4c63e82-9c26-4b34-8dfb-31a3db35c3a1"),
            ReferenceBillerUid = new Guid("fffd5b07-1b50-4d13-a9d7-92c5e3a87c9c"),
            ReferenceTerminalUid = new Guid("d19752e5-b3f6-49c8-a240-a32dc70f635c"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option C\"}").RootElement,
            BillerName = "Sample Biller Inc. C",
            IsExtraData = true,
            IsCompilance = false,
            MaxStubs = 8,
            PaymentTypes = JsonDocument.Parse("[\"Crypto Currency\", \"Google Pay\"]").RootElement,
            Industries = [
                new ()
                {
                    Id = 1,
                    IndustryName = "Electronics",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                },
                new ()
                {
                    Id = 2,
                    IndustryName = "Domestic Appliance",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                }
            ],
            CreatedDatetime = DateTime.UtcNow.AddDays(-5),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        },
        new ()
        {
            Id = 4,
            BillerInfoUid = new Guid("1dc05324-af2b-4d1c-b82c-43f432168184"),
            PartnerIdUid = new Guid("b8f7d4f6-152b-4b7e-b83b-88e3b9c3c1c1"),
            ReferenceBillerUid = new Guid("c522b8ef-1604-40f0-bc29-1ef8bb334504"),
            ReferenceTerminalUid = new Guid("d19752e5-b3f6-49c8-a240-a32dc70f635c"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option D\"}").RootElement,
            BillerName = "Sample Biller Inc. D",
            IsExtraData = false,
            IsCompilance = true,
            MaxStubs = 6,
            PaymentTypes = JsonDocument.Parse("[\"Apple Pay\", \"Venmo\"]").RootElement,
            Industries = [
                new ()
                {
                    Id = 1,
                    IndustryName = "Gas",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                },
                new ()
                {
                    Id = 2,
                    IndustryName = "Electricity",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = "AdminUser",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "AdminUser"
                }
            ],
            CreatedDatetime = DateTime.UtcNow.AddDays(-3),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        }
    ];
}
