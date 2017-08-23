using System;
using Autofac.Extras.Moq;
using DailyBilling.Common.Lib11.BusinessObjects;
using DailyBilling.Common.Lib11.SOAReport;
using FluentAssertions;
using Xunit;
using DailyBilling.Common.Lib11.DataSources;
using Moq;
using System.Collections.Generic;
using DailyBilling.Tests.TestTools;

namespace DailyBilling.Tests.SOAReport
{
    [Trait("SOA Report", "Solitary")]
    public class SOAReportBuilderFacts
    {
        [Fact(DisplayName = "First day, no payment")]
        public void SOAContractStart()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            var rep = sut.Build(lse, lse.Start);

            rep.Rows.Count.Should().Be(3);

            rep.Rows[0].Date.Should().Be(5.February(2014));
            rep.Rows[0].Rent.StartBalance.Should().Be(0);
            rep.Rows[0].Rent.Target.Regular.Should().Be(0);
            rep.Rows[0].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[0].Rent.CellPayment.Should().Be(0);
            rep.Rows[0].Rent.EndBalance.Should().Be(0);
            rep.Rows[0].Rights.StartBalance.Should().Be(0);
            rep.Rows[0].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.Rows[1].Date.Should().Be(6.February(2014));
            rep.Rows[1].Rent.StartBalance.Should().Be(0);
            rep.Rows[1].Rent.Target.Regular.Should().Be(0);
            rep.Rows[1].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[1].Rent.CellPayment.Should().Be(0);
            rep.Rows[1].Rent.EndBalance.Should().Be(0);
            rep.Rows[1].Rights.StartBalance.Should().Be(lse.Rights.TotalAmount);
            rep.Rows[1].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.Rows[2].Date.Should().Be(7.February(2014));
            rep.Rows[2].Rent.StartBalance.Should().Be(0);
            rep.Rows[2].Rent.Target.Regular.Should().Be(lse.Rent.Rate);
            rep.Rows[2].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[2].Rent.CellPayment.Should().Be(0);
            rep.Rows[2].Rent.EndBalance.Should().Be(lse.Rent.Rate);
            rep.Rows[2].Rights.StartBalance.Should().Be(lse.Rights.TotalAmount);
            rep.Rows[2].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.RentBalance.Should().Be(lse.Rent.Rate);
            rep.OverdueRights.Should().Be(0);
            rep.TotalRightsBalance.Should().Be(lse.Rights.TotalAmount);
        }


        [Fact(DisplayName = "First day, exact rent paid")]
        public void Firstdayrentpaid()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            var src = moq.Mock<IPaymentSource>();
            src.Setup(_ => _.GetPayments(Any.Lease, lse.Rent.FirstDue)).Returns(new List<IPayment>
            {
                Mock.Of<IPayment>(_ => _.RentAmount == 100)
            });

            var rep = sut.Build(lse, lse.Start);

            rep.Rows.Count.Should().Be(3);

            rep.Rows[0].Date.Should().Be(5.February(2014));
            rep.Rows[0].Rent.StartBalance.Should().Be(0);
            rep.Rows[0].Rent.Target.Regular.Should().Be(0);
            rep.Rows[0].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[0].Rent.CellPayment.Should().Be(0);
            rep.Rows[0].Rent.EndBalance.Should().Be(0);
            rep.Rows[0].Rights.StartBalance.Should().Be(0);
            rep.Rows[0].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.Rows[1].Date.Should().Be(6.February(2014));
            rep.Rows[1].Rent.StartBalance.Should().Be(0);
            rep.Rows[1].Rent.Target.Regular.Should().Be(0);
            rep.Rows[1].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[1].Rent.CellPayment.Should().Be(0);
            rep.Rows[1].Rent.EndBalance.Should().Be(0);
            rep.Rows[1].Rights.StartBalance.Should().Be(lse.Rights.TotalAmount);
            rep.Rows[1].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.Rows[2].Date.Should().Be(7.February(2014));
            rep.Rows[2].Rent.StartBalance.Should().Be(0);
            rep.Rows[2].Rent.Target.Regular.Should().Be(lse.Rent.Rate);
            rep.Rows[2].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[2].Rent.CellPayment.Should().Be(lse.Rent.Rate);
            rep.Rows[2].Rent.EndBalance.Should().Be(0);
            rep.Rows[2].Rights.StartBalance.Should().Be(lse.Rights.TotalAmount);
            rep.Rows[2].Rights.Target.Regular.Should().Be(0);
            rep.Rows[2].Rights.Target.Penalty.Should().Be(0);
            rep.Rows[2].Rights.CellPayment.Should().Be(0);
            rep.Rows[2].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.RentBalance.Should().Be(0);
            rep.OverdueRights.Should().Be(0);
            rep.TotalRightsBalance.Should().Be(lse.Rights.TotalAmount);
        }


        private LotContract CreateSampleContract()
        {
            var c                = new LotContract();
            c.Submitted          = 5.February(2014);
            c.Start              = 7.February(2014);

            c.Rent               = new RentParams();
            c.Rent.Rate          = 100;
            c.Rent.FirstDue      = c.Start;

            c.Rights             = new RightsParams();
            c.Rights.TotalAmount = 5000;
            c.Rights.DueDate     = c.Start.AddMonths(6);

            return c;
        }

        private SOAReportBuilder CreateSUT(out AutoMock moq)
        {
            moq     = AutoMock.GetLoose();
            var sut = moq.Create<SOAReportBuilder>();
            return sut;
        }
    }
}
