namespace dev_lambda_billpay;
public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }

    public Result()
    {

    }

    public Result(bool isSuccess, T data, string errorMessage = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }
}

