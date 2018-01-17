using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantApp.Roman;

namespace MerchantAppTest
{
        /// <summary>
        /// This class tests whether the Roman to Decimal conversion works as expected.
        /// </summary>
        [TestClass]
        public class RomanConverterTest
        {
                [TestMethod]
                public void TestConversion()
                {
                        RomanConverter converter = new RomanConverter();
                        Assert.AreEqual<double>(converter.ToDecimal("MCMXLIV").Value, 1944);
                        Assert.AreEqual<double>(converter.ToDecimal("DXXI").Value, 521);
                        Assert.AreEqual<double>(converter.ToDecimal("CMXCII").Value, 992);
                        Assert.AreNotEqual<double>(converter.ToDecimal("IV").Value, 6);
                }
        }
}
