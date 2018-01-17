using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantApp.Roman.Rules;

namespace MerchantAppTest
{
        /// <summary>
        /// This class tests the rules set for Roman to Decimal conversion.
        /// </summary>
        [TestClass]
        public class RulesTest
        {
                [TestMethod]
                public void TestCantBeRepeatedRule()
                {
                        CantBeRepeated rule = new CantBeRepeated();
                        Assert.IsFalse(rule.Execute("MMDD"));
                        Assert.IsFalse(rule.Execute("XVIV"));
                        Assert.IsTrue(rule.Execute("XXIV"));
                }

                [TestMethod]
                public void TestCantBeRepeated4TimesRule()
                {
                        CantBeRepeated4Times rule = new CantBeRepeated4Times();
                        Assert.IsFalse(rule.Execute("XXXX"));
                        Assert.IsTrue(rule.Execute("IXIXIXIX"));
                        Assert.IsTrue(rule.Execute("XXXIX"));
                }

                [TestMethod]
                public void TestSingleSubtractionRule()
                {
                        SingleSubtraction rule = new SingleSubtraction();
                        Assert.IsFalse(rule.Execute("IIX"));
                        Assert.IsFalse(rule.Execute("CCM"));
                        Assert.IsTrue(rule.Execute("XXIV"));
                }

                [TestMethod]
                public void TestSubtractionRule()
                {
                        Subtraction rule = new Subtraction();
                        Assert.IsFalse(rule.Execute("CIL"));
                        Assert.IsFalse(rule.Execute("MXD"));
                        Assert.IsTrue(rule.Execute("XIX"));
                }
        }
}
