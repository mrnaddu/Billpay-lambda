using System.Text.Json;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public class BillerHelper
{
    private static readonly List<BillerInfoDto> billerInfoList =
    [
        new BillerInfoDto
        {
            Id = 1,
            BillerInfoId = new Guid("03f7b867-3f3e-4fbb-961a-7fe4c9a9329f"),
            PartnerId = new Guid("e8b6c62a-69b8-48c7-88f4-91f98272b694"),
            BillerId = new Guid("0c6e6b27-77b1-4b3f-94c3-5d3a6e8c0fe5"),
            MerchantId = new Guid("1354a199-69e8-4a7d-9b6a-6a434029b9cc"),
            TerminalId = new Guid("6b023e5b-06c5-4b1e-bc5d-6d46d0e3e3b6"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option A\"}").RootElement,
            BillerName = "Sample Biller Inc. A",
            ExtraDataRequired = true,
            MaxStubs = 5,
            PaymentTypes = JsonDocument.Parse("[\"Credit Card\", \"Bank Transfer\"]").RootElement,
            CreatedDatetime = DateTime.UtcNow.AddDays(-7),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        },
        new BillerInfoDto
        {
            Id = 2,
            BillerInfoId = new Guid("d6b2e4a2-6c7f-493b-b12f-9d1d8fe1f3e3"),
            PartnerId = new Guid("f1a42f3c-83d7-4a62-8baa-3c524fd45e1b"),
            BillerId = new Guid("be82a1a5-4e47-4b16-92a1-01a419f3e15c"),
            MerchantId = new Guid("6f97f22c-1c16-4927-af21-1c34f6f6e75e"),
            TerminalId = new Guid("11fe1d45-5dc0-4c15-9e62-aa2c9dcb5053"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option B\"}").RootElement,
            BillerName = "Sample Biller Inc. B",
            ExtraDataRequired = false,
            MaxStubs = 3,
            PaymentTypes = JsonDocument.Parse("[\"Debit Card\", \"PayPal\"]").RootElement,
            CreatedDatetime = DateTime.UtcNow.AddDays(-10),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        },
        new BillerInfoDto
        {
            Id = 3,
            BillerInfoId = new Guid("837f1232-b632-45d3-badf-68d5f9e9d6e1"),
            PartnerId = new Guid("a4c63e82-9c26-4b34-8dfb-31a3db35c3a1"),
            BillerId = new Guid("fffd5b07-1b50-4d13-a9d7-92c5e3a87c9c"),
            MerchantId = new Guid("0f445ace-2b2a-4f67-b5fb-0b019c27e45b"),
            TerminalId = new Guid("e2f1a89a-94f2-4f44-a7ab-d94c0b6a4b23"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option C\"}").RootElement,
            BillerName = "Sample Biller Inc. C",
            ExtraDataRequired = true,
            MaxStubs = 8,
            PaymentTypes = JsonDocument.Parse("[\"Crypto Currency\", \"Google Pay\"]").RootElement,
            CreatedDatetime = DateTime.UtcNow.AddDays(-5),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        },
        new BillerInfoDto
        {
            Id = 4,
            BillerInfoId = new Guid("1dc05324-af2b-4d1c-b82c-43f432168184"),
            PartnerId = new Guid("b8f7d4f6-152b-4b7e-b83b-88e3b9c3c1c1"),
            BillerId = new Guid("c522b8ef-1604-40f0-bc29-1ef8bb334504"),
            MerchantId = new Guid("e4d45c16-67f7-4647-9816-b314e44f23d1"),
            TerminalId = new Guid("01d0e3b2-9242-4d64-9ebe-8911dcd1f7b1"),
            BillChoice = JsonDocument.Parse("{\"option\": \"Option D\"}").RootElement,
            BillerName = "Sample Biller Inc. D",
            ExtraDataRequired = false,
            MaxStubs = 6,
            PaymentTypes = JsonDocument.Parse("[\"Apple Pay\", \"Venmo\"]").RootElement,
            CreatedDatetime = DateTime.UtcNow.AddDays(-3),
            CreatedBy = "AdminUser",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "AdminUser"
        }
    ];

    public static List<BillerInfoDto> GetAllBillers()
    {
        return billerInfoList;
    }
}
