using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.BalanceAdjustments
{
    public class RightsBalanceMemo : BalanceAdjustmentBase
    {
        public RightsBalanceMemo(ILease lease) : base(lease, lease.Rights)
        {
        }
    }
}
