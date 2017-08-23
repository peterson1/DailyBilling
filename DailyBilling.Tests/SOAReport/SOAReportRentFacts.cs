using Autofac.Extras.Moq;
using DailyBilling.Common.Lib11.BusinessObjects;
using DailyBilling.Common.Lib11.DataSources;
using DailyBilling.Common.Lib11.SOAReport;
using DailyBilling.Tests.TestTools;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DailyBilling.Tests.SOAReport
{
    [Trait("SOA Report", "Solitary")]
    public class SOAReportRentFacts
    {
        [Fact(DisplayName = "Before start: no rent payables")]
        public void Beforestartnorentpayables()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            var rep = sut.Build(lse, 6.February(2014));
            rep.Rows.Count.Should().Be(2);

            rep.Rows[0].Date.Should().Be(5.February(2014));
            rep.Rows[0].Rent.StartBalance.Should().Be(0);
            rep.Rows[0].Rent.Target.Regular.Should().Be(0);
            rep.Rows[0].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[0].Rent.CellPayment.Should().Be(0);
            rep.Rows[0].Rent.EndBalance.Should().Be(0);

            rep.Rows[1].Date.Should().Be(6.February(2014));
            rep.Rows[1].Rent.StartBalance.Should().Be(0);
            rep.Rows[1].Rent.Target.Regular.Should().Be(0);
            rep.Rows[1].Rent.Target.Penalty.Should().Be(0);
            rep.Rows[1].Rent.CellPayment.Should().Be(0);
            rep.Rows[1].Rent.EndBalance.Should().Be(0);

            rep.RentBalance.Should().Be(0);
        }


        [Fact(DisplayName = "Day 1: no rent paid")]
        public void SOAContractStart()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            var rep = sut.Build(lse, 7.February(2014));
            rep.Rows.Count.Should().Be(3);
            var row = rep.Rows[2];

            row.Date.Should().Be(7.February(2014));
            row.Rent.StartBalance.Should().Be(0);
            row.Rent.Target.Regular.Should().Be(100);
            row.Rent.Target.Penalty.Should().Be(0);
            row.Rent.CellPayment.Should().Be(0);
            row.Rent.EndBalance.Should().Be(100);

            rep.RentBalance.Should().Be(lse.Rent.Rate);
        }


        [Fact(DisplayName = "Day 1: exact rent paid")]
        public void Firstdayrentpaid()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            moq.SetPayment(lse.Rent.FirstDue, 100, 0);

            var rep = sut.Build(lse, 7.February(2014));
            rep.Rows.Count.Should().Be(3);
            var row = rep.Rows[2];

            row.Date.Should().Be(7.February(2014));
            row.Rent.StartBalance.Should().Be(0);
            row.Rent.Target.Regular.Should().Be(100);
            row.Rent.Target.Penalty.Should().Be(0);
            row.Rent.CellPayment.Should().Be(100);
            row.Rent.EndBalance.Should().Be(0);

            rep.RentBalance.Should().Be(0);
        }


        [Fact(DisplayName = "Day 2: no rent paid")]
        public void Day2norentpaid()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            var rep = sut.Build(lse, 8.February(2014));
            rep.Rows.Count.Should().Be(4);
            var row = rep.Rows[3];

            row.Date.Should().Be(8.February(2014));
            row.Rent.StartBalance.Should().Be(100);

            row.Rent.Target.Regular.Should().Be(100);
            row.Rent.Target.Penalty.Should().Be(5);

            row.Rent.CellPayment.Should().Be(0);
            row.Rent.EndBalance.Should().Be(205);

            rep.RentBalance.Should().Be(205);
        }


        [Fact(DisplayName = "Day 2: exact rent paid")]
        public void Day2exactrentpaid()
        {
            var sut = CreateSUT(out AutoMock moq);
            var lse = CreateSampleContract();
            moq.SetPayment(7.February(2014), 100, 0);
            moq.SetPayment(8.February(2014), 100, 0);

            var rep = sut.Build(lse, 8.February(2014));
            rep.Rows.Count.Should().Be(4);
            var row = rep.Rows[3];

            row.Date.Should().Be(8.February(2014));
            row.Rent.StartBalance.Should().Be(0);

            row.Rent.Target.Regular.Should().Be(100);
            row.Rent.Target.Penalty.Should().Be(0);

            row.Rent.CellPayment.Should().Be(100);
            row.Rent.EndBalance.Should().Be(0);

            rep.RentBalance.Should().Be(0);
        }


        private LotContract CreateSampleContract()
        {
            var c                = new LotContract();
            c.Submitted          = 5.February(2014);
            c.Start              = 7.February(2014);

            c.Rent               = new RentParams();
            c.Rent.Rate          = 100;
            c.Rent.Penalty       = 5;
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
