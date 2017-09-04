using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Common.Lib11.BusinessRules
{
    public interface IPenaltyRule
    {
        string   RuleKey       { get; }
        string   Formula       { get; }
        string   MemoTitle     { get; }
        double   GetSurcharge  (ILease lease, DateTime date);
    }
}
