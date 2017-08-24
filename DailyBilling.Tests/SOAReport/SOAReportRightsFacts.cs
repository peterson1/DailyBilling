using Autofac.Extras.Moq;
using DailyBilling.Common.Lib11.BusinessObjects;
using DailyBilling.Common.Lib11.SOAReport;
using FluentAssertions;
using Xunit;

namespace DailyBilling.Tests.SOAReport
{
    [Trait("SOA Report", "Solitary")]
    public class SOAReportRightsFacts
    {
        [Fact(DisplayName = "Day 1: no rights paid")]
        public void SOAContractStart()
        {
            var sut = SUT.Create(out AutoMock moq);
            var lse = CreateSampleContract();
            var rep = sut.Build(lse, lse.Start);

            rep.Rows.Count.Should().Be(3);

            rep.Rows[0].Date.Should().Be(5.February(2014));
            rep.Rows[0].Rights.StartBalance.Should().Be(0);
            rep.Rows[0].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.Rows[1].Date.Should().Be(6.February(2014));
            rep.Rows[1].Rights.StartBalance.Should().Be(lse.Rights.TotalAmount);
            rep.Rows[1].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

            rep.Rows[2].Date.Should().Be(7.February(2014));
            rep.Rows[2].Rights.StartBalance.Should().Be(lse.Rights.TotalAmount);
            rep.Rows[2].Rights.EndBalance.Should().Be(lse.Rights.TotalAmount);

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
    }
}
