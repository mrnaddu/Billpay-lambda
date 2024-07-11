using Billpay_lambda.Dtos;
using Billpay_lambda.Exceptions;
using Billpay_lambda.Helpers;

namespace Billpay_lambda.Managers;

public class BillPayManager
{
    public ResultDto<AtmDto> GetNearByTerminal(double lat, double lng)
    {
        try
        {
            var atmList = AtmHelper.GetAllAtms();
            if (atmList.Count == 0)
                throw new NotFoundException("There is error while fetching atm list");

            var matchingAtms = atmList.Where(atm => atm.Lat == lat && atm.Lng == lng).ToList();

            if (matchingAtms.Count == 0)
                throw new NotFoundException($"Terminal Not found for the lattitude: {lat}, longitude: {lng}");

            return ResultDto<AtmDto>.SuccessResult(matchingAtms.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return ResultDto<AtmDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<BillerInfoDto> GetBillersByTerminal(Guid terminalId)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.TerminalId == terminalId).ToList();

            if (matchingBillers.Count == 0)
                throw new NotFoundException($"Biller Not found for selected terminal {terminalId}");

            return ResultDto<BillerInfoDto>.SuccessResult(matchingBillers.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return ResultDto<BillerInfoDto>.FailureResult($"Exception: {ex.Message}");
        }
    }

    public ResultDto<ProcessBillPayDto> ProcessBillpayDetails(ProcessBillPayInputDto input)
    {
        try
        {
            var billerList = BillerHelper.GetAllBillers();
            if (billerList.Count == 0)
                throw new NotFoundException("There is error while fetching biller list");

            var matchingBillers = billerList.Where(biller => biller.BillerInfoId == input.BillerId).FirstOrDefault() ?? throw new NotFoundException($"Biller Not found for selected terminal {input.BillerId}");
            if (matchingBillers.ExtraDataRequired == false)
            {
                var response = new ProcessBillPayDto
                {
                    TerminalId = input.TerminalId,
                    TransactionId = Guid.NewGuid(),
                    BillerId = input.BillerId,
                    ScreenData = new ScreenDataDto()
                    {
                        DataElement =
                        [
                            new() {
                                Id = Guid.NewGuid(),
                                Label= "Account Number",
                                IsNumber = true,
                                IsRequired = true,
                                ElementType = "text",
                                MaxLength = 25,
                                Notification= [
                                    new() {
                                        NotificationType = "info",
                                        NotificationDescription = "Enter the full name of the customer."
                                    }
                                ]
                            },
                            new() {
                                Id = Guid.NewGuid(),
                                Label= "Amount",
                                IsNumber = true,
                                IsRequired = true,
                                ElementType = "number",
                                MaxLength = 10,
                                Notification= [
                                    new() {
                                        NotificationType = "info",
                                        NotificationDescription = "Amount must be a number."
                                    }
                                ]
                            }
                        ],
                        ExtraInfo = null,
                        Denominator = new DenominatorDto()
                        {
                            type = "percentage",
                            Value = 100
                        }
                    }
                };
                return ResultDto<ProcessBillPayDto>.SuccessResult(response);
            }
            else
            {
                var response = new ProcessBillPayDto
                {
                    TerminalId = input.TerminalId,
                    TransactionId = Guid.NewGuid(),
                    BillerId = input.BillerId,
                    ScreenData = new ScreenDataDto()
                    {
                        DataElement = null,
                        ExtraInfo =
                        [
                             new() {
                                Id = Guid.NewGuid(),
                                Label= "Customer Name",
                                IsNumber = false,
                                IsRequired = false,
                                ElementType = "text",
                                MaxLength = 50,
                                Notification= [
                                    new() {
                                        NotificationType = "info",
                                        NotificationDescription = "Enter the full name of the customer."
                                    }
                                ]
                            },
                           new() {
                                Id = Guid.NewGuid(),
                                Label= "Payment Date",
                                IsNumber = false,
                                IsRequired = true,
                                ElementType = "date",
                                MaxLength = 10,
                                 Notification= [
                                    new() {
                                        NotificationType = "error",
                                        NotificationDescription = "Payment date is required."
                                    }
                                ]
                           }
                        ],
                        Denominator = new DenominatorDto()
                        {
                            type = "percentage",
                            Value = 100
                        }
                    }
                };
                return ResultDto<ProcessBillPayDto>.SuccessResult(response);
            }
        }
        catch (Exception ex)
        {
            return ResultDto<ProcessBillPayDto>.FailureResult($"Exception: {ex.Message}");
        }
    }
}
