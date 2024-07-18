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

    public ResultDto<ProcessBillPayDto> ProcessBillpay(ProcessBillPayInputDto input)
    {
        var result = billPayManager.ProcessBillpayDetails(input);
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

    public ResultDto<UserTransactionSummaryDto> GeteTransactionSummaries(Guid userId)
    {
        throw new NotImplementedException();
    }
}
