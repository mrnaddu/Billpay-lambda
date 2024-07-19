using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public static class TransactionHistoryHelper
{
    public static List<TransactionSummaryDto> GetPrestageHistory(Guid userId)
    {
        var prestageHistory = new List<TransactionSummaryDto>
    {
        new ()
        {
            Id = 1,
            TransactionId = Guid.NewGuid(),
            UserId = userId,
            TerminalId = Guid.NewGuid(),
            PartnerId = Guid.NewGuid(),
            SessionId = Guid.NewGuid(),
            TransactionReferenceId = Guid.NewGuid(),
            Currency = "INR",
            TransactionProvisioner = "Fiserv",
            TransactionType = "SendMoney",
            TransactionAmount = 700.0,
            TransactionFee = 10.0,
            TransactionStatus = "Completed",
            CreatedDateTime = DateTime.UtcNow,
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow,
            ModifiedBy = "Admin"
        },
        new ()
        {
            Id = 2,
            TransactionId = Guid.NewGuid(),
            UserId = userId,
            TerminalId = Guid.NewGuid(),
            PartnerId = Guid.NewGuid(),
            SessionId = Guid.NewGuid(),
            TransactionReferenceId = Guid.NewGuid(),
            Currency = "EUR",
            TransactionProvisioner = "Fiserv",
            TransactionType = "Withdraw",
            TransactionAmount = 560.0,
            TransactionFee = 209.0,
            TransactionStatus = "Completed",
            CreatedDateTime = DateTime.UtcNow.AddDays(-1),
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow.AddDays(-1),
            ModifiedBy = "Admin"
        },
        new ()
        {
            Id = 2,
            TransactionId = Guid.NewGuid(),
            UserId = userId,
            TerminalId = Guid.NewGuid(),
            PartnerId = Guid.NewGuid(),
            SessionId = Guid.NewGuid(),
            TransactionReferenceId = Guid.NewGuid(),
            Currency = "USD",
            TransactionProvisioner = "Fiserv",
            TransactionType = "Withdraw",
            TransactionAmount = 5090.0,
            TransactionFee = 289.0,
            TransactionStatus = "Completed",
            CreatedDateTime = DateTime.UtcNow.AddDays(-1),
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow.AddDays(-1),
            ModifiedBy = "Admin"
        }
    };

        return prestageHistory;
    }
}
