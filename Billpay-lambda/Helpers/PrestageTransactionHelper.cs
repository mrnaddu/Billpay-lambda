using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Helpers;

public static class PrestageTransactionHelper
{
    public static PrestageTransactionOutputDto CreatePrestageTransaction(Guid userId, Guid TransactionId)
    {
        var prestageTransaction = new PrestageTransactionOutputDto()
        {
            UserInfo = new()
            {
                Id = 1,
                UserId = userId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = 1234567890,
                Address = "123 Main St, Anytown, USA",
                Otc = "1234",
                OtcExpiryDateTime = DateTime.UtcNow.AddHours(1),
            },
            TransactionSummary = new()
            {
                Id = 1,
                TransactionId = TransactionId,
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
                TransactionStatus = "Success",
                CreatedDateTime = DateTime.UtcNow,
                CreatedBy = "Admin",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedBy = "Admin"
            }
        };

        return prestageTransaction;
    }
}

