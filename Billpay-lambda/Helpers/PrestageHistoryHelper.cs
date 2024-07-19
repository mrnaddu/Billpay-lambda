using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public static class PrestageHistoryHelper
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
            Currency = "USD",
            TransactionProvisioner = "Fiserv",
            TransactionType = "SendMoney",
            TransactionAmount = 100.0,
            TransactionFee = 5.0,
            TransactionStatus = "Prestage",
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
            TransactionProvisioner = "PayPal",
            TransactionType = "Withdraw",
            TransactionAmount = 50.0,
            TransactionFee = 2.0,
            TransactionStatus = "Prestage",
            CreatedDateTime = DateTime.UtcNow.AddDays(-1),
            CreatedBy = "Admin",
            ModifiedDateTime = DateTime.UtcNow.AddDays(-1),
            ModifiedBy = "Admin"
        }
    };

        return prestageHistory;
    }
}
