using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Common.Lib11.DataSources
{
    public interface IRightsBalanceSource
    {
        double GetStartBalance(ILease lse, DateTime date);
    }
}
