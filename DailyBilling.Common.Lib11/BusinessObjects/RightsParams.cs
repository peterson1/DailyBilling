using System;

namespace DailyBilling.Common.Lib11.BusinessObjects
{
    public class RightsParams
    {
        public enum PenaltyModes
        {
            Unknown = 0,
            PercentInterest_DailyAfter90
        }


        public double        TotalAmount   { get; set; }
        public DateTime      DueDate       { get; set; }
        public PenaltyModes  PenaltyMode   { get; set; }
        public double        PenaltyRate1  { get; set; }
        public double        PenaltyRate2  { get; set; }
    }
}
