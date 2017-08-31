namespace DailyBilling.Common.Lib11.Abstractions
{
    public enum BillInterval
    {
        Unknown = 0,
        Free,
        OneTime,
        Daily,
        Weekly,
        Monthly,
    }


    public interface ILeaseAccount
    {
        string         Label        { get; }
        double?        Balance      { get; }
        BillInterval   Interval     { get; }
        string         PenaltyRule  { get; }
    }
}
