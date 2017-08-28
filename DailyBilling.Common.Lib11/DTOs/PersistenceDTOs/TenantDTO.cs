using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Common.Lib11.DTOs.PersistenceDTOs
{
    public class TenantDTO : PersistenceDTOBase, ITenant
    {
        public string    FirstName  { get; set; }
        public string    LastName   { get; set; }
        public DateTime  BirthDay   { get; set; }
    }
}
