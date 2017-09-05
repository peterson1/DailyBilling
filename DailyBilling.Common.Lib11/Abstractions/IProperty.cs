namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface IProperty
    {
        ulong           Id     { get; }
        string          Label  { get; }
        IPropertyGroup  Group  { get; }
    }
}
