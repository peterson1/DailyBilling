using DailyBilling.Common.Lib11.BusinessObjects;
using DailyBilling.Common.Lib11.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyBilling.Common.Lib11.SOAReport
{
    public class SOAReportBuilder
    {
        private IPaymentSource _src;


        public SOAReportBuilder(IPaymentSource paymentSource)
        {
            _src = paymentSource;
        }


        public SOAReportVM Build(LotContract lse, DateTime asOfDate)
        {
            var report     = new SOAReportVM();
            report.Rows    = new List<SOAReportRow>();
            var prevRent   = default(SOAReportCell);
            var prevRights = default(SOAReportCell);

            for (var date = lse.Submitted; date <= asOfDate; date = date.AddDays(1))
            {
                var payments   = _src.GetPayments(lse, date);
                var rentCell   = GetRentCell  (lse, date, payments, prevRent);
                var rightsCell = GetRightsCell(lse, date, payments, prevRights);

                report.Rows.Add(new SOAReportRow
                {
                    Date     = date,
                    Payments = payments,
                    Rent     = rentCell,
                    Rights   = rightsCell,
                });
                prevRent   = rentCell;
                prevRights = rightsCell;
            }

            report.RentBalance        = report.Rows.Last().Rent.EndBalance;
            report.TotalRightsBalance = report.Rows.Last().Rights.EndBalance;

            return report;
        }


        private SOAReportCell GetRentCell(LotContract lse, DateTime date, List<IPayment> payments, SOAReportCell prevDay)
        {
            var cell         = new SOAReportCell();
            cell.Target      = new CellTarget();
            cell.CellPayment = payments?.Sum(_ => _.RentAmount) ?? 0;

            cell.StartBalance = prevDay?.EndBalance ?? 0;

            if (date >= lse.Rent.FirstDue)
                cell.Target.Regular = lse.Rent.Rate;

            if (cell.StartBalance != 0)
                cell.Target.Penalty = cell.StartBalance * lse.Rent.PenaltyRate;

            cell.EndBalance = cell.StartBalance 
                            + cell.Target.Total()
                            - cell.CellPayment;
            return cell;
        }


        private SOAReportCell GetRightsCell(LotContract lse, DateTime date, List<IPayment> payments, SOAReportCell prevDay)
        {
            var cell = new SOAReportCell();
            cell.Target = new CellTarget();
            if (date == lse.Submitted)
                cell.EndBalance = lse.Rights.TotalAmount;
            else
            {
                cell.StartBalance = prevDay.EndBalance;
                cell.EndBalance = cell.StartBalance;
            }

            return cell;
        }
    }
}
