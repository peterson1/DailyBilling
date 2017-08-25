using System;

namespace DailyBilling.Common.Lib11.BusinessObjects
{

    public class RentParams
    {
        public enum Frequency
        {
            Unknown = 0,
            Daily,
        }


        public enum PenaltyModes
        {
            Unknown = 0,
            PercentInterest
        }


        public double        Rate          { get; set; }
        public DateTime      FirstDue      { get; set; }
        public Frequency     Interval      { get; set; }
        public PenaltyModes  PenaltyMode   { get; set; }
        public double        PenaltyRate1  { get; set; }
        public double        PenaltyRate2  { get; set; }
    }
}