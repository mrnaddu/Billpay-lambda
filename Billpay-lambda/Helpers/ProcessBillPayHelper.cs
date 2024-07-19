using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public class ProcessBillPayHelper
{
    public static ProcessBillPayDto GetWithoutExtraData(Guid terminalId, Guid billerId)
    {
        var withoutExtradata = new ProcessBillPayDto()
        {
            TerminalId = terminalId,
            BillerId = billerId,
            TransactionId = Guid.Empty,
            ScreenData = new()
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
                ExtraInfo = new (){
                    ExtraData = [
                        new (){

                            Key = "SameDay,SameBusiness day(NC)",
                            Value = "$4.00"
                        },
                        new (){
                            Key = "NextDay,1 Business day",
                            Value = "$0.00"
                        },
                        new(){
                            Key = "Standard, 3 Business days",
                            Value = "$3.00"
                        }
                        ]

                }
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
                WaterMark = "enter the amount",
                Notification =
                [
                    new ()
                    {
                        NotificationType = "info",
                        NotificationDescription = "Your biller will credit you for accessing the amount."
                    }
                ],
                ExtraInfo = new ()
                {
                    Denominator = 4
                }
            }
        ],
                ScreenId = 1,
                ScreenType = "WithoutExtraData"
            }
        };

        return withoutExtradata;

    }

    public static ProcessBillPayDto GetWitExtraData(Guid terminalId, Guid billerId)
    {
        var withExtradata = new ProcessBillPayDto()
        {
            TerminalId = terminalId,
            BillerId = billerId,
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
            }
        };

        return withExtradata;
    }

    public static ProcessBillPayDto GetCompilance(Guid terminalId, Guid billerId)
    {
        var Compilance = new ProcessBillPayDto()
        {
            TerminalId = terminalId,
            BillerId = billerId,
            TransactionId = Guid.Empty,
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
        return Compilance;
    }

    public static ProcessBillPayDto GetTransactionSummary()
    {
        var withoutExtradata = new ProcessBillPayDto()
        {
            ScreenData = new ScreenDataDto()
            {
                DataElements = [
                    new ()
                    {
                        Notification = [
                            new ()
                            {
                                NotificationType = "info",
                                NotificationDescription = "Successfully created transactions"
                            }
                        ],
                        ExtraInfo = null
                    }
                    ]
            }
        };

        return withoutExtradata;

    }
}

