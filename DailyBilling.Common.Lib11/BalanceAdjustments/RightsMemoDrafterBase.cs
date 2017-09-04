using DailyBilling.Common.Lib11.Abstractions;
using DailyBilling.Common.Lib11.BusinessRules;
using System;
using System.Collections.Generic;

namespace DailyBilling.Common.Lib11.BalanceAdjustments
{
    public abstract class RightsMemoDrafterBase : IRightsMemoDrafter
    {
        private Dictionary<string, IPenaltyRule> _rules;


        public RightsBalanceMemo  CreateDraftMemo  (ILease lse, DateTime effectiveDate)
        {
            var rule = GetRule(lse.Rights.PenaltyRule);
            return new RightsBalanceMemo(lse)
            {
                Title         = rule.MemoTitle,
                Amount        = rule.GetSurcharge(lse, effectiveDate),
                EffectiveDate = effectiveDate,
                Remarks       = rule.Formula
            };
        }


        private IPenaltyRule GetRule(string ruleKey)
        {
            if (string.IsNullOrWhiteSpace(ruleKey))
                throw new ArgumentNullException("lse.Rights.PenaltyRule should NOT be BLANK.");

            if (!_rules.TryGetValue(ruleKey, out IPenaltyRule rule))
                throw new ArgumentException($"Unsupported Rights Penalty Rule: {ruleKey}");

            return rule;
        }


        protected void AddRule(string ruleKey, IPenaltyRule penaltyRule)
        {
            if (_rules == null)
                _rules = new Dictionary<string, IPenaltyRule>();

            _rules.Add(ruleKey, penaltyRule);
        }


        protected void AddRule<T>(T penaltyRule) where T : IPenaltyRule
            => AddRule(typeof(T).Name, penaltyRule);
    }
}
