using DailyBilling.Common.Lib11.BusinessObjects;
using System;
using System.Collections.Generic;

namespace DailyBilling.Common.Lib11.SOAReport
{
    public class SOAReportRow
    {
        public DateTime        Date      { get; set; }
        public List<IPayment>  Payments  { get; set; }
        public SOAReportCell   Rent      { get; set; }
        public SOAReportCell   Rights    { get; set; }
    }
}
