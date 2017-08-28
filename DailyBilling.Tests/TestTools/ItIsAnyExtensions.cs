using DailyBilling.Common.Lib11.Abstractions;
using Moq;
using System;

namespace DailyBilling.Tests.TestTools
{
    public class Any
    {
        public static ILease       Lease  => It.IsAny<ILease>();
        public static bool         Bool   => It.IsAny<bool>();
        public static DateTime     Day    => It.IsAny<DateTime>();
        public static ulong        ULong  => It.IsAny<ulong>();
        public static uint         UInt   => It.IsAny<uint>();
        public static string       Text   => It.IsAny<string>();
        public static object       Obj    => It.IsAny<object>();
    }
}
