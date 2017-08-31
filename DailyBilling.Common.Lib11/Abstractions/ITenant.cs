using System;

namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface ITenant
    {
        string    FirstName  { get; }
        string    LastName   { get; }
        DateTime  BirthDay   { get; }


        //  derived
        string    FullName   { get; }
    }
}
