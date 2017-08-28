using System;

namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface IRentAccount : ILeaseAccount
    {
        double     RegularRate    { get; }
        double     PenaltyRate1   { get; }
        double     PenaltyRate2   { get; }
        DateTime   FirstDueDate   { get; }
    }
}
