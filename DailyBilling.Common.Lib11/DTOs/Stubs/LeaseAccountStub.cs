using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.DTOs.Stubs
{
    public class LeaseAccountStub : ILeaseAccount
    {
        public string         Label        { get; set; }
        public double         Balance      { get; set; }
        public BillInterval   Interval     { get; set; }
        public string         PenaltyRule  { get; set; }
    }
}
