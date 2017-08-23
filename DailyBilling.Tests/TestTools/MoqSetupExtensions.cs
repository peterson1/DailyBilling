using Autofac.Extras.Moq;
using DailyBilling.Common.Lib11.BusinessObjects;
using DailyBilling.Common.Lib11.DataSources;
using Moq;
using System;
using System.Collections.Generic;

namespace DailyBilling.Tests.TestTools
{
    public static class MoqSetupExtensions
    {
        public static void SetPayment(this AutoMock moq, 
            DateTime date, double rentPayment, double rightsPayment)
        {
            var src = moq.Mock<IPaymentSource>();
            src.Setup(_ => _.GetPayments(Any.Lease, date)).Returns(new List<IPayment>
            {
                Mock.Of<IPayment>(_ => _.RentAmount == 100)
            });
        }
    }
}
