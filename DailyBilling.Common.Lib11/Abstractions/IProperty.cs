namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface IProperty
    {
        string          Label  { get; }
        IPropertyGroup  Group  { get; }
    }
}
