namespace Billpay_lambda.Consts;

public class DataElementsValue
{
    // wihout extra data
    public const string nextDay = "NextDay,1 Business day $0.00";
    public const string sameDay = "SameDay,SameBusiness day(NC) $4.00";
    public const string standardDay = "Standard, 3 Business days $3.00";

    // with extra data
    public const string TXS = "Texas";
    public const string ALA = "Alaska";
    public const string NYK = "New York";

    public const string dev1 = "Division One";
    public const string dev2 = "Division Two";
    public const string dev3 = "Division Three";
}
