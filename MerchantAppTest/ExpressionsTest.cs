using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantApp.Roman.Expressions;
using MerchantApp.Shared;
using MerchantApp.Roman;

namespace MerchantAppTest
{
        /// <summary>
        /// This class tests some of the expression classes that are used to identify and execute the expressions provided by the user.
        /// </summary>
        [TestClass]
        public class ExpressionsTest
        {
                [TestMethod]
                public void AliasExpressionTest()
                {
                        AliasMapper aliasMap = new AliasMapper();
                        AliasExpression expression = new AliasExpression(aliasMap);
                        Assert.IsTrue(expression.Match("glob is C"));
                        Assert.IsFalse(expression.Match("glob is N"));
                        expression.Execute("glob is C");
                        Assert.IsTrue(aliasMap.Exists("glob"));
                        Assert.IsTrue(String.Equals(aliasMap.GetValueForAlias("glob"), "C"));
                }

                [TestMethod]
                public void UnitExpressionTest()
                {
                        AliasMapper aliasMap = new AliasMapper();
                        RomanConverter converter = new RomanConverter();
                        CommodityIndex commodityIndex = new CommodityIndex();
                        aliasMap.AddAlias("glob", "C");
                        aliasMap.AddAlias("pish", "X");
                        ExpressionValidationHelper helper = new ExpressionValidationHelper(aliasMap, commodityIndex);
                        UnitExpression expression = new UnitExpression(commodityIndex, aliasMap, converter, helper);
                        expression.Execute("pish glob Iron is 7020 Credits");
                        Assert.IsTrue(commodityIndex.Exists("Iron"));
                        Assert.AreEqual<double>(commodityIndex.GetPriceByCommodity("Iron"), 78);
                        expression.Execute("pish glob Iron is 6300 Credits");
                        Assert.AreEqual<double>(commodityIndex.GetPriceByCommodity("Iron"), 70);
                }
        }
}
