using DailyBilling.Common.Lib11.Abstractions;
using DailyBilling.Common.Lib11.BusinessRules;
using DailyBilling.Common.Lib11.DataSources;
using System;
using System.Collections.Generic;

namespace DailyBilling.Common.Lib11.BalanceAdjustments
{
    public abstract class RightsMemoDrafterBase : IRightsMemoDrafter
    {
        private IRightsBalanceSource             _src;
        private Dictionary<string, IPenaltyRule> _rules;


        public RightsMemoDrafterBase(IRightsBalanceSource rightsBalanceSource)
        {
            _src = rightsBalanceSource;
        }


        public RightsBalanceMemo  CreateDraftMemo  (ILease lse, DateTime date)
        {
            var memo = new RightsBalanceMemo(lse)
            {
                Description   = "Daily Rights Surcharge Memo",
                EffectiveDate = date,
                Amount        = ComputeMemoAmount(lse, date)
            };
            return memo.Amount == 0 ? null : memo;
        }


        protected void AddRule(string ruleKey, IPenaltyRule penaltyRule)
        {
            if (_rules == null)
                _rules = new Dictionary<string, IPenaltyRule>();

            _rules.Add(ruleKey, penaltyRule);
        }


        protected void AddRule<T>(T penaltyRule) where T : IPenaltyRule
            => AddRule(typeof(T).Name, penaltyRule);


        private double ComputeMemoAmount(ILease lse, DateTime date)
        {
            var ruleKey = lse.Rights.PenaltyRule;

            if (!_rules.TryGetValue(ruleKey, out IPenaltyRule rule))
                throw new ArgumentException($"Unsupported Rights Penalty Rule: {ruleKey}");

            var bal = _src.GetStartBalance(lse, date);
            return rule.GetSurcharge(lse, bal, date);
        }
    }
}
