using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Common.Lib11.BalanceAdjustments
{
    public interface IRightsMemoDrafter
    {
        RightsBalanceMemo  CreateDraftMemo  (ILease lse, DateTime date);
    }
}
