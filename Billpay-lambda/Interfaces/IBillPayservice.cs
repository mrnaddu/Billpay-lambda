﻿using Billpay_lambda.InputDtos;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Interfaces;

public interface IBillPayservice
{
    ResultDto<List<AtmDto>> GetTerminal(double lat, double lng);
    ResultDto<List<BillerInfoDto>> GetAllBillers(Guid terminalId);
    ResultDto<ProcessBillPayDto> ProcessBillpay(ProcessBillPayInputDto input);
    ResultDto<List<BillerInfoDto>> GetTopBillers(Guid terminalId);
    ResultDto<BillerInfoDto> GetBiller(Guid billerId);
    ResultDto<List<BillerInfoDto>> GetBillerCategory(Guid terminalId);
    ResultDto<string> StoreUserPreference(UserPreferenceInputDto input);
    ResultDto<UserPreferenceOutputDto> GetUserPreference(Guid userId);
    ResultDto<UserTransactionSummaryDto> GetTransactionSummaries(Guid userId);
    ResultDto<PrestageTransactionOutputDto> PrestageTransaction(PrestageTransactionInputDto input);
    ResultDto<List<TransactionSummaryDto>> GetPrestageTransaction(Guid UserId);
}
