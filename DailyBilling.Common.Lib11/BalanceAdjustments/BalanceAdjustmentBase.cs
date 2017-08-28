using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Common.Lib11.BalanceAdjustments
{
    public class BalanceAdjustmentBase : IBalanceAdjustment
    {
        public BalanceAdjustmentBase(ILease lease, ILeaseAccount leaseAccount)
        {
            Lease   = lease;
            Account = leaseAccount;
        }


        public ILease          Lease           { get; }
        public ILeaseAccount   Account         { get; }
        public string          Description     { get; set; }
        public double          Amount          { get; set; }
        public DateTime        EffectiveDate   { get; set; }
        public string          ReferenceNum    { get; set; }
        public string          Remarks         { get; set; }
        public string          PostedBy        { get; set; }
        public DateTime        PostedDate      { get; set; }
    }
}
