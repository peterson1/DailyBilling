using DailyBilling.Common.Lib11.BusinessObjects;
using System;

namespace DailyBilling.Common.Lib11.DataSources
{
    public interface IRightsBalanceSource
    {
        double GetStartBalance(LotContract lse, DateTime date);
    }
}
