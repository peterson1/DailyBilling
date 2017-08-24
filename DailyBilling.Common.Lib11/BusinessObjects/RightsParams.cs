using System;

namespace DailyBilling.Common.Lib11.BusinessObjects
{
    public class RightsParams
    {
        public enum PenaltyModes
        {
            Unknown = 0,
            PercentInterest
        }


        public double        TotalAmount  { get; set; }
        public DateTime      DueDate      { get; set; }
        public PenaltyModes  PenaltyMode  { get; set; }
        public double        PenaltyRate  { get; set; }
    }
}
