namespace DailyBilling.Common.Lib11.SOAReport
{
    public class SOAReportCell
    {
        public double       StartBalance  { get; set; }
        public CellTarget   Target        { get; set; }
        public double       CellPayment   { get; set; }
        public double       EndBalance    { get; set; }
    }
}
