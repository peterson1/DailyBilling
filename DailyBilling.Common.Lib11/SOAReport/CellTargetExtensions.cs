namespace DailyBilling.Common.Lib11.SOAReport
{
    public static class CellTargetExtensions
    {
        public static double Total(this CellTarget cellTarg)
            => cellTarg.Regular + cellTarg.Penalty;
    }
}
