using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public class ProcessBillPayHelper
{
    public static ProcessBillPayDto GetWithoutExtraData()
    {
        return withoutExtraData;
    }

    public static ProcessBillPayDto GetWitExtraData()
    {
        return withExtraData;
    }

    public static ProcessBillPayDto GetCompilance()
    {
        return compilance;
    }

    private static readonly ProcessBillPayDto withoutExtraData = new()
    {
        TerminalId = Guid.NewGuid(),
        BillerId = Guid.NewGuid(),
        TransactionId = Guid.Empty,
        ScreenData = new ScreenDataDto
        {
            DataElements =
            [
                new ()
                {
                    Id = "DeliveryType",
                    Label = "GetDeliveryType",
                    IsNumber = false,
                    IsRequired = true,
                    ElementType = "dropdown",
                    MaxLength = 0,
                    MinLength = 0,
                    WaterMark = "Select the delivery type",
                    Notification = null,
                    ExtraInfo = null
                },
                new ()
                {
                    Id = "AccountNumber",
                    Label = "GetAccountNumber",
                    IsNumber = true,
                    IsRequired = true,
                    ElementType = "number",
                    MaxLength = 10,
                    MinLength = 5,
                    WaterMark = "enter the account number",
                    Notification = null,
                    ExtraInfo = null
                },
                new ()
                {
                    Id = "Amount",
                    Label = "GetAmount",
                    IsNumber = true,
                    IsRequired = true,
                    ElementType = "number",
                    MaxLength = 10,
                    MinLength = 5,
                    WaterMark = "ente the amount",
                    Notification =
                    [
                        new ()
                        {
                            NotificationType = "info",
                            NotificationDescription = "Your biller will credit you for access the amount."
                        }
                    ],
                    ExtraInfo = new ExtraInfoDto
                    {
                        Denominator = 4
                    }
                }
            ],
            ScreenId = 1,
            ScreenType = "WithoutExtraData"
        },
    };

    private static readonly ProcessBillPayDto withExtraData = new()
    {
        TerminalId = Guid.NewGuid(),
        BillerId = Guid.NewGuid(),
        TransactionId = Guid.Empty,
        ScreenData = new ScreenDataDto
        {
            DataElements =
        [
            new ()
                {
                    Id = "DivisionNumber",
                    Label = "GetDivisionNumber",
                    IsNumber = false,
                    IsRequired = true,
                    ElementType = "dropdown",
                    MaxLength = 0,
                    MinLength = 0,
                    WaterMark = "Select the division number",
                    Notification = null,
                    ExtraInfo = null
                },
                new ()
                {
                    Id = "SelectState",
                    Label = "GetSelectState",
                    IsNumber = false,
                    IsRequired = true,
                    ElementType = "dropdown",
                    MaxLength = 0,
                    MinLength = 0,
                    WaterMark = "Select the state",
                    Notification = null,
                    ExtraInfo = null
                }
        ],
            ScreenId = 2,
            ScreenType = "WithExtraData"
        },
    };

    private static readonly ProcessBillPayDto compilance = new()
    {
        TerminalId = Guid.NewGuid(),
        BillerId = Guid.NewGuid(),
        TransactionId = Guid.NewGuid(),
        ScreenData = new ScreenDataDto
        {
            DataElements =
        [
            new ()
                {
                    Id = "GovermentNumber",
                    Label = "GetGovermentNumber",
                    IsNumber = true,
                    IsRequired = true,
                    ElementType = "number",
                    MaxLength = 15,
                    MinLength = 5,
                    WaterMark = "Enter the government number",
                    Notification = null,
                    ExtraInfo = null
                },
                new ()
                {
                    Id = "DateOfBirth",
                    Label = "GetDateOfBirth",
                    IsNumber = false,
                    IsRequired = true,
                    ElementType = "number",
                    MaxLength = 0,
                    MinLength = 0,
                    WaterMark = "Enter the date of birth",
                    Notification = null,
                    ExtraInfo = null
                }
        ],
            ScreenId = 3,
            ScreenType = "Compilance"
        },
    };
}

