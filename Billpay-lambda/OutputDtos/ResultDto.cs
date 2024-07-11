namespace Billpay_lambda.OutputDtos;

public class ResultDto<T>
{
    public bool Success { get; protected set; }
    public string Message { get; protected set; }
    public T Data { get; protected set; }
    public Exception Exception { get; protected set; }

    protected ResultDto(bool success, string message, T data, Exception exception = null)
    {
        Success = success;
        Message = message;
        Data = data;
        Exception = exception;
    }

    public static ResultDto<T> SuccessResult(T data)
    {
        return new ResultDto<T>(true, "Operation successful", data);
    }

    public static ResultDto<T> FailureResult(string message, Exception exception = null)
    {
        return new ResultDto<T>(false, message, default, exception);
    }
}
