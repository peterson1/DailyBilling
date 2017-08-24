using System;

namespace DailyBilling.Common.Lib11.BusinessObjects.BalanceAdjustments
{
    public class BalanceAdjustmentBase
    {
        public string         Title          { get; set; }
        public DateTime       EffectiveDate  { get; set; }
        public double         Amount         { get; set; }
        public string         Remarks        { get; set; }
        public AuthoringInfo  AuthoringInfo  { get; set; }
    }
}
