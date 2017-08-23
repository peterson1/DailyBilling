using DailyBilling.Common.Lib11.BusinessObjects;
using System;
using System.Collections.Generic;

namespace DailyBilling.Common.Lib11.DataSources
{
    public interface IPaymentSource
    {
        List<IPayment> GetPayments(LotContract contract, DateTime date);
    }
}
