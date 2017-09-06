namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface IBankAccount
    {
        ulong   Id     { get; }
        string  Label  { get; }
    }
}
