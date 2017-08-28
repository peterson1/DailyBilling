using System;

namespace DailyBilling.Common.Lib11.Abstractions
{
    public interface ILease
    {
        ITenant       Tenant           { get; }
        IProperty     Property         { get; }
                                       
        DateTime      ContractStart    { get; }
        DateTime      ContractEnd      { get; }
        DateTime      Submitted        { get; }
        DateTime?     Terminated       { get; }
        ILease        FormerLease      { get; }
                                      
        IRentAccount     Rent          { get; }
        IRightsAccount   Rights        { get; }
    }
}
