using Billpay_lambda.Consts;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public class ProcessBillPayHelper
{
    public static ProcessBillPayDto GetWithoutExtraData(Guid terminalId, Guid billerId, Guid? transactionId = null)
    {
        var withoutExtradata = new ProcessBillPayDto()
        {
            TerminalId = terminalId,
            BillerId = billerId,
            TransactionId = transactionId ?? Guid.Empty,
            TransactionStatus = "Started",
            TrnsactionMessage = "Transaction started with the basic fields",
            ScreenData = new()
            {
                DataElements =
        [
            new ()
            {
                Id = DataElementsLabel.DeliveryType,
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
                            Value = DataElementsValue.sameDay
                        },
                        new (){
                            Value = DataElementsValue.nextDay
                        },
                        new(){
                            Value = DataElementsValue.standardDay
                        }
                        ]
                }
            },
            new ()
            {
                Id = DataElementsLabel.AccountNumber,
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
                Id = DataElementsLabel.Amount,
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
                ScreenType = ScreenTypes.WithoutExtraData
            }
        };

        return withoutExtradata;

    }

    public static ProcessBillPayDto GetWithExtraData(Guid terminalId, Guid billerId)
    {
        var withExtradata = new ProcessBillPayDto()
        {
            TerminalId = terminalId,
            BillerId = billerId,
            TransactionId = Guid.Empty,
            TransactionStatus = "Started",
            TrnsactionMessage = "Transaction started with the extra fields",
            ScreenData = new ScreenDataDto
            {
                DataElements =
        [
            new ()
                {
                    Id = DataElementsLabel.DivisionNumber,
                    Label = "GetDivisionNumber",
                    IsNumber = false,
                    IsRequired = true,
                    ElementType = "dropdown",
                    MaxLength = 0,
                    MinLength = 0,
                    WaterMark = "Select the division number",
                    Notification = null,
                    ExtraInfo = new (){
                    ExtraData = [
                        new (){
                            Value = DataElementsValue.dev1
                        },
                        new (){
                            Value = DataElementsValue.dev2
                        },
                        new(){
                            Value = DataElementsValue.dev3
                        }
                        ]
                }
                },
                new ()
                {
                    Id = DataElementsLabel.SelectState,
                    Label = "GetSelectState",
                    IsNumber = false,
                    IsRequired = true,
                    ElementType = "dropdown",
                    MaxLength = 0,
                    MinLength = 0,
                    WaterMark = "Select the state",
                    Notification = null,
                    ExtraInfo = new (){
                    ExtraData = [
                        new (){
                            Value = DataElementsValue.NYK
                        },
                        new (){
                            Value = DataElementsValue.ALA
                        },
                        new(){
                            Value = DataElementsValue.TXS
                        }
                        ]
                }
                }
        ],
                ScreenType = ScreenTypes.WithExtraData
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
            TransactionId = Guid.NewGuid(),
            TransactionStatus = "Pending",
            TrnsactionMessage = "Transaction started and more verifications required",
            ScreenData = new ScreenDataDto
            {
                DataElements =
        [
            new ()
                {
                    Id = DataElementsLabel.GovermentNumber,
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
                    Id = DataElementsLabel.DateOfBirth,
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
                ScreenType = ScreenTypes.Compilance
            },
        };
        return Compilance;
    }

    public static ProcessBillPayDto GetTransactionSummary(Guid terminalId, Guid billerId, Guid? transactionId = null)
    {
        var transactionSummary = new ProcessBillPayDto()
        {
            TerminalId = terminalId,
            BillerId = billerId,
            TransactionId = transactionId ?? Guid.NewGuid(),
            TransactionStatus = "Created",
            TrnsactionMessage = "Transaction  created, And create a prestage code",
            ScreenData = null
        };

        return transactionSummary;
    }
}

