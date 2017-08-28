using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Tests.Stubs
{
    public class LeaseAccountStub : ILeaseAccount
    {
        public string         Label        { get; set; }
        public double         Balance      { get; set; }
        public BillInterval   Interval     { get; set; }
        public string         PenaltyRule  { get; set; }
    }
}
