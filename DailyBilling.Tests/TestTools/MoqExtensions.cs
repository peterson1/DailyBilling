using DailyBilling.Common.Lib11.BusinessObjects;
using Moq;
using System;

namespace DailyBilling.Tests.TestTools
{
    public class Any
    {
        public static LotContract  Lease  => It.IsAny<LotContract>();
        public static bool         Bool   => It.IsAny<bool>();
        public static DateTime     Day    => It.IsAny<DateTime>();
        public static ulong        ULong  => It.IsAny<ulong>();
        public static uint         UInt   => It.IsAny<uint>();
        public static string       Text   => It.IsAny<string>();
        public static object       Obj    => It.IsAny<object>();
    }
}
