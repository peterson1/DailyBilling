using System;

namespace DailyBilling.Common.Lib11.BusinessObjects
{
    public enum RentInterval
    {
        Unknown = 0,
        Daily,
        Monthly,
    }


    public class RentParams
    {
        public double         Rate       { get; set; }
        public double         Penalty    { get; set; }
        public RentInterval   Interval   { get; set; }
        public DateTime       FirstDue   { get; set; }
    }
}