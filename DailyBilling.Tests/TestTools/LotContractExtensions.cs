using DailyBilling.Common.Lib11.BusinessObjects;

namespace DailyBilling.Tests.TestTools
{
    public static  class LotContractExtensions
    {
        public static LotContract InstantiateProperties(this LotContract lse)
        {
            lse.Tenant = new Tenant();
            lse.Lot    = new RentableLot();
            lse.Rent   = new RentParams();
            lse.Rights = new RightsParams();
            return lse;
        }
    }
}
