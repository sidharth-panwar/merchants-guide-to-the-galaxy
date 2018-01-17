using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Expressions
{
        /// <summary>
        /// This class checks for and parses unit question expressions. For e.g.,
        /// How many credits is pish pish Iron?
        /// </summary>
        public class UnitQuestionExpression : IExpression
        {
                private AliasMapper aliasMap;
                private CommodityIndex commodityIndex;
                private IDecimalConverter converter;
                private ExpressionValidationHelper helper;

                public UnitQuestionExpression(CommodityIndex commodityIndex, AliasMapper aliasMap, IDecimalConverter converter, ExpressionValidationHelper helper)
                {
                        this.commodityIndex = commodityIndex;
                        this.aliasMap = aliasMap;
                        this.converter = converter;
                        this.helper = helper;
                }

                public void Execute(string input)
                {
                        //Remove question mark
                        input = input.Substring(0, input.Length - 1);

                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        string commodity = words[words.Length - 1];
                        StringBuilder sb = new StringBuilder();

                        //Create Roman Numeral from aliases
                        for (int i = 0; i < words.Length - 1; i++)
                        {
                                sb.Append(aliasMap.GetValueForAlias(words[i]));
                        }

                        //Convert Roman to Decimal
                        double? totalUnits = converter.ToDecimal(sb.ToString());
                        if (totalUnits.HasValue) Console.WriteLine(String.Format("{0} is {1}", parts[1], totalUnits.Value * commodityIndex.GetPriceByCommodity(commodity)));
                }

                public bool Match(string input)
                {
                        //Remove question mark
                        input = input.Substring(0, input.Length - 1);

                        bool isQuestion = (input.StartsWith("how many", StringComparison.OrdinalIgnoreCase));
                        if (!isQuestion) return false;

                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2) return false;

                        string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length < 1) return false;

                        return helper.AreWordsValidAliases(words.Take(words.Length - 1).ToArray()) &&
                                helper.AreWordsValidCommodities(words.Skip(words.Length-1).ToArray());
                }

                
        }
}
