using System;

namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface IRightsAccount : ILeaseAccount
    {
        double      TotalAmount    { get; }
        DateTime    DueDate        { get; }
        double      PenaltyRate1   { get; }
        double      PenaltyRate2   { get; }
    }
}
