using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.DTOs.Stubs
{
    public class GLAccountStub : IGLAccount
    {
        public ulong   Id     { get; set; }
        public string  Label  { get; set; }
    }
}
