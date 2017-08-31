using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.BusinessRules
{
    public static class TenantExtensions
    {
        public static string GetFullName(this ITenant tenant)
            => $"{tenant.FirstName} {tenant.LastName}";
    }
}
