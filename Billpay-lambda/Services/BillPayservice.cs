using Billpay_lambda.InputDtos;
using Billpay_lambda.Interfaces;
using Billpay_lambda.Managers;
using Billpay_lambda.OutputDtos;

namespace Billpay_lambda.Services;

public class BillPayservice : IBillPayservice
{
    private readonly BillPayManager billPayManager;
    public BillPayservice(BillPayManager billPayManager)
    {
        this.billPayManager = billPayManager;
    }

    public ResultDto<BillerInfoDto> GetBiller(Guid billerId)
    {
        var result = billPayManager.GetBiller(billerId);
        if (result.Success)
            return ResultDto<BillerInfoDto>.SuccessResult(result.Data);

        return ResultDto<BillerInfoDto>.FailureResult(result.Message);
    }

    public ResultDto<List<BillerInfoDto>> GetAllBillers(Guid terminalId)
    {
        var result = billPayManager.GetBillersByTerminal(terminalId);
        if (result.Success)
            return ResultDto<List<BillerInfoDto>>.SuccessResult(result.Data);

        return ResultDto<List<BillerInfoDto>>.FailureResult(result.Message);
    }

    public ResultDto<List<AtmDto>> GetTerminal(double lat, double lng)
    {
        var result = billPayManager.GetNearByTerminal(lat, lng);
        if (result.Success)
            return ResultDto<List<AtmDto>>.SuccessResult(result.Data);

        return ResultDto<List<AtmDto>>.FailureResult(result.Message);
    }

    public ResultDto<List<BillerInfoDto>> GetTopBillers(Guid terminalId)
    {
        var result = billPayManager.GetTopBillers(terminalId);
        if (result.Success)
            return ResultDto<List<BillerInfoDto>>.SuccessResult(result.Data);

        return ResultDto<List<BillerInfoDto>>.FailureResult(result.Message);
    }

    public ResultDto<ProcessBillPayDto> ProcessBillpay(Guid terminalId, Guid billerId, ProcessBillPayInputDto input)
    {
        var result = billPayManager.ProcessBillpayDetails(terminalId, billerId, input);
        if (result.Success)
            return ResultDto<ProcessBillPayDto>.SuccessResult(result.Data);

        return ResultDto<ProcessBillPayDto>.FailureResult(result.Message);
    }

    public ResultDto<List<BillerInfoDto>> GetBillerCategory(Guid terminalId)
    {
        var result = billPayManager.GetBillerCategory(terminalId);
        if (result.Success)
            return ResultDto<List<BillerInfoDto>>.SuccessResult(result.Data);

        return ResultDto<List<BillerInfoDto>>.FailureResult(result.Message);
    }

    public ResultDto<string> StoreUserPreference(UserPreferenceInputDto input)
    {
        var result = billPayManager.StoreUserPreference(input.UserInoId, input.TenantIds);
        if (result.Success)
            return ResultDto<string>.SuccessResult(result.Data);

        return ResultDto<string>.FailureResult(result.Message);
    }

    public ResultDto<UserPreferenceOutputDto> GetUserPreference(Guid userId)
    {
        var result = billPayManager.GetUserPreference(userId);
        if (result.Success)
            return ResultDto<UserPreferenceOutputDto>.SuccessResult(result.Data);

        return ResultDto<UserPreferenceOutputDto>.FailureResult(result.Message);
    }

    public ResultDto<UserTransactionSummaryDto> GetTransactionSummaries(Guid userId)
    {
        var result = billPayManager.GetTransactionSummaries(userId);
        if (result.Success)
            return ResultDto<UserTransactionSummaryDto>.SuccessResult(result.Data);

        return ResultDto<UserTransactionSummaryDto>.FailureResult(result.Message);
    }

    public ResultDto<PrestageTransactionOutputDto> PrestageTransaction(Guid userId, Guid TransactionId)
    {
        var result = billPayManager.CreatePrestageTransaction(userId, TransactionId);
        if (result.Success)
            return ResultDto<PrestageTransactionOutputDto>.SuccessResult(result.Data);

        return ResultDto<PrestageTransactionOutputDto>.FailureResult(result.Message);
    }

    public ResultDto<List<TransactionSummaryDto>> GetPrestageTransaction(Guid userId)
    {
        var result = billPayManager.GetPrestageTransaction(userId);
        if (result.Success)
            return ResultDto<List<TransactionSummaryDto>>.SuccessResult(result.Data);

        return ResultDto<List<TransactionSummaryDto>>.FailureResult(result.Message);
    }

    public ResultDto<List<TransactionSummaryDto>> GetTransactionHistory(Guid userId)
    {
        var result = billPayManager.GetTransactionHistory(userId);
        if (result.Success)
            return ResultDto<List<TransactionSummaryDto>>.SuccessResult(result.Data);

        return ResultDto<List<TransactionSummaryDto>>.FailureResult(result.Message);
    }
}
