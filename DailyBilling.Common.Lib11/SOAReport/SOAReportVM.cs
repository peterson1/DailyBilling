using System.Collections.Generic;

namespace DailyBilling.Common.Lib11.SOAReport
{
    public class SOAReportVM
    {
        public List<SOAReportRow> Rows               { get; set; }
        public double             RentBalance        { get; set; }
        public double             OverdueRights      { get; set; }
        public double             TotalRightsBalance { get; set; }
    }
}
