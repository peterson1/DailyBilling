using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Common.Lib11.BusinessRules
{
    public interface IPenaltyRule
    {
        string   RuleKey       { get; }
        string   Description   { get; }
        double   GetSurcharge  (ILease lease, double startBalance, DateTime date);
    }
}
