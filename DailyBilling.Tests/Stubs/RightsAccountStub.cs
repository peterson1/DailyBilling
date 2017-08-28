using DailyBilling.Common.Lib11.Abstractions;
using System;

namespace DailyBilling.Tests.Stubs
{
    public class RightsAccountStub : LeaseAccountStub, IRightsAccount
    {
        public double      TotalAmount    { get; set; }
        public DateTime    DueDate        { get; set; }
        public double      PenaltyRate1   { get; set; }
        public double      PenaltyRate2   { get; set; }
    }
}
