using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.DTOs.Stubs
{
    public class BankAccountStub : IBankAccount
    {
        public ulong   Id     { get; set; }
        public string  Label  { get; set; }
    }
}
