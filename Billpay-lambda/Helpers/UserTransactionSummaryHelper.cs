using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public static class UserTransactionSummaryHelper
{
    public static List<UserTransactionSummaryDto> GetTransactionSummary()
    {
        return userTransactionSummary;
    }

    private static readonly List<UserTransactionSummaryDto> userTransactionSummary =
        [
        new ()
        {
            Id = 1,
            UserUid = new Guid("f59d8aeb-3c7b-42a1-ae0e-c42b094e6583"),
            UserName = "John Doe",
            Email = "john.doe@example.com",
            Phone = 1234567890,
            Address = "123 Main St, Anytown, USA",
            TransactionSummaries =
            [
                new ()
                {
                    Id = 1,
                    TerminalUid = Guid.NewGuid(),
                    PartnerUid = Guid.NewGuid(),
                    MerchantUid = Guid.NewGuid(),
                    SessionUid = Guid.NewGuid(),
                    TransactionReferenceUid = Guid.NewGuid(),
                    Currency = "USD",
                    TransactionType = "Send Money",
                    TransactionAmount = 100.0,
                    TransactionFee = 5.0,
                    TransactionStatus = "Completed",
                    DeliveryOption = "2 Days delivery",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-1),
                    CreatedBy = "Admin",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "Admin"
                },
                new ()
                {
                    Id = 1,
                    TerminalUid = Guid.NewGuid(),
                    PartnerUid = Guid.NewGuid(),
                    MerchantUid = Guid.NewGuid(),
                    SessionUid = Guid.NewGuid(),
                    TransactionReferenceUid = Guid.NewGuid(),
                    Currency = "USD",
                    TransactionType = "Send Money",
                    TransactionAmount = 1200.0,
                    TransactionFee = 90.0,
                    TransactionStatus = "Completed",
                    DeliveryOption = "Same Days delivery",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-1),
                    CreatedBy = "Admin",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "Admin"
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
            TransactionSummaries =
            [
                new ()
                {
                    Id = 1,
                    TerminalUid = Guid.NewGuid(),
                    PartnerUid = Guid.NewGuid(),
                    MerchantUid = Guid.NewGuid(),
                    SessionUid = Guid.NewGuid(),
                    TransactionReferenceUid = Guid.NewGuid(),
                    Currency = "INR",
                    TransactionType = "Send Money",
                    TransactionAmount = 500.0,
                    TransactionFee = 10.0,
                    TransactionStatus = "Pending",
                    DeliveryOption = "3 Days delivery",
                    CreatedDatetime = DateTime.UtcNow.AddDays(-1),
                    CreatedBy = "Admin",
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedBy = "Admin"
                }
            ],
            CreatedDatetime = DateTime.UtcNow,
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "Admin"
        }
        ];
}
