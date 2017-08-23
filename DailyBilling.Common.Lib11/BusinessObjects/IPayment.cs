namespace DailyBilling.Common.Lib11.BusinessObjects
{
    public interface IPayment
    {
        double     RentAmount    { get; }
        double     RightsAmount  { get; }
        Collector  Collector     { get; }
    }
}
