using DailyBilling.Common.Lib11.Abstractions;
using DailyBilling.Common.Lib11.BusinessRules;
using System;

namespace DailyBilling.Common.Lib11.DTOs.Stubs
{
    public class TenantStub : ITenant
    {
        public string    FirstName  { get; set; }
        public string    LastName   { get; set; }
        public DateTime  BirthDay   { get; set; }


        public string FullName => this.GetFullName();

        public override string ToString() => this.FullName;
    }
}
