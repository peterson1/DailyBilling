using System;

namespace DailyBilling.Common.Lib11.BusinessObjects
{
    public class RightsParams
    {
        public double     TotalAmount   { get; set; }
        public double     Penalty       { get; set; }
        public DateTime   DueDate       { get; set; }
    }
}
