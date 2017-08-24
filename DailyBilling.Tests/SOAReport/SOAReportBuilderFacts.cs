using Autofac.Extras.Moq;
using DailyBilling.Common.Lib11.BusinessObjects;
using DailyBilling.Tests.TestTools;
using FluentAssertions;
using System;
using Xunit;

namespace DailyBilling.Tests.SOAReport
{
    [Trait("SOA: Validations", "Solitary")]
    public class SOAReportBuilderFacts
    {
        [Fact(DisplayName = "Validates Rent Frequency")]
        public void ValidatesRentFrequency()
        {
            var sut  = SUT.Create(out AutoMock moq);
            var lse  = new LotContract().InstantiateProperties();

            lse.Rent.Interval = RentParams.Frequency.Unknown;

            sut.Invoking(_ => _.Build(lse, Any.Day))
               .ShouldThrow<ArgumentException>();
        }


        [Fact(DisplayName = "Validates Rent Penalty Mode")]
        public void ValidatesPenaltyMode()
        {
            var sut = SUT.Create(out AutoMock moq);
            var lse = new LotContract().InstantiateProperties();

            lse.Rent.PenaltyMode = RentParams.PenaltyModes.Unknown;

            sut.Invoking(_ => _.Build(lse, Any.Day))
               .ShouldThrow<ArgumentException>();
        }
    }
}
