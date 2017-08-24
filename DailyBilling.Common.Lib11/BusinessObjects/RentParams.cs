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


        public enum PenaltyMode
        {
            Unknown = 0,
            Interest
        }


        public double       Rate       { get; set; }
        public double       Interest   { get; set; }
        public DateTime     FirstDue   { get; set; }
        public Frequency    Interval   { get; set; }
        public PenaltyMode  Penalty    { get; set; }
    }
}