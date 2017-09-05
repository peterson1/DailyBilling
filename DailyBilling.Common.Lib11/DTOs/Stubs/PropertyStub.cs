using DailyBilling.Common.Lib11.Abstractions;

namespace DailyBilling.Common.Lib11.DTOs.Stubs
{
    public class PropertyStub : IProperty
    {
        public ulong           Id     { get; set; }
        public string          Label  { get; set; }
        public IPropertyGroup  Group  { get; set; }


        public override string ToString() => Label;
    }
}
