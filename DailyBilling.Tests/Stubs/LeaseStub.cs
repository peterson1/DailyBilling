using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Tests.Stubs
{
    public class LeaseStub : ILease
    {
        public ITenant          Tenant           { get; set; }
        public IProperty        Property         { get; set; }
        public DateTime         ContractStart    { get; set; }
        public DateTime         ContractEnd      { get; set; }
        public DateTime         Submitted        { get; set; }
        public DateTime?        Terminated       { get; set; }
        public ILease           FormerLease      { get; set; }
        public IRentAccount     Rent             { get; set; }
        public IRightsAccount   Rights           { get; set; }
    }
}
