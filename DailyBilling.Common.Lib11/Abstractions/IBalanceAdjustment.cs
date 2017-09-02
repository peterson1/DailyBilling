using System;

namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface IBalanceAdjustment
    {
        ILease          Lease           { get; }
        ILeaseAccount   Account         { get; }
        string          Title           { get; }
        double          Amount          { get; }
        DateTime        EffectiveDate   { get; }
        string          ReferenceNum    { get; }
        string          Remarks         { get; }
        string          PostedBy        { get; }
        DateTime        PostedDate      { get; }
    }
}
