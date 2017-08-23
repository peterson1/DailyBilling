using System;

namespace DailyBilling.Common.Lib11.BusinessObjects
{
    public class LotContract
    {
        public Tenant        Tenant     { get; set; }
        public Lot           Lot        { get; set; }
                                        
        public DateTime      Submitted  { get; set; }
        public DateTime      Start      { get; set; }
        public DateTime      End        { get; set; }
                                        
        public RentParams    Rent       { get; set; }
        public RightsParams  Rights     { get; set; }
    }
}
