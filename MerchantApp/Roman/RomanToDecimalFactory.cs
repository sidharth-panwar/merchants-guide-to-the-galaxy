using MerchantApp.Roman.Expressions;
using MerchantApp.Roman.Rules;
using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman
{
        /// <summary>
        /// This class establishes the rules for a Roman to Decimal conversion.
        /// </summary>
        public class RomanToDecimalFactory
        {
                public static List<IConversionRule> GetRules()
                {
                        List<IConversionRule> rules = new List<IConversionRule>();
                        rules.Add(new CantBeRepeated());
                        rules.Add(new CantBeRepeated4Times());
                        rules.Add(new SingleSubtraction());
                        rules.Add(new Subtraction());

                        return rules;
                }

                public static List<IExpression> GetExpressions(AliasMapper aliasMap, IDecimalConverter converter, CommodityIndex commodityIndex, ExpressionValidationHelper helper)
                {
                        List<IExpression> expressions = new List<IExpression>();
                        expressions.Add(new AliasExpression(aliasMap));
                        expressions.Add(new UnitExpression(commodityIndex, aliasMap, converter, helper));
                        expressions.Add(new AliasQuestionExpression(aliasMap, converter, helper));
                        expressions.Add(new UnitQuestionExpression(commodityIndex, aliasMap, converter, helper));
                        expressions.Add(new CommodityConversionExpression(commodityIndex, aliasMap, converter, helper));

                        return expressions;
                }
        }
}
