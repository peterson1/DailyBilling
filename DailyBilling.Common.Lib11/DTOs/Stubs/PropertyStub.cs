using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.DTOs.Stubs
{
    public class PropertyStub : IProperty
    {
        public string          Label  { get; set; }
        public IPropertyGroup  Group  { get; set; }
    }
}
