using Autofac.Extras.Moq;
using DailyBilling.Common.Lib11.SOAReport;

namespace DailyBilling.Tests.SOAReport
{
    class SUT
    {
        public static SOAReportBuilder Create(out AutoMock moq)
        {
            moq = AutoMock.GetLoose();
            var sut = moq.Create<SOAReportBuilder>();
            return sut;
        }
    }
}
