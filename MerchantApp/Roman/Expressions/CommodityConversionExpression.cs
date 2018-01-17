using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Expressions
{
        public class CommodityConversionExpression : IExpression
        {
                private AliasMapper aliasMap;
                private CommodityIndex commodityIndex;
                private IDecimalConverter converter;
                private ExpressionValidationHelper helper;

                public CommodityConversionExpression(CommodityIndex commodityIndex, AliasMapper aliasMap, IDecimalConverter converter, ExpressionValidationHelper helper)
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

                        string[] preIsWords = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] postIsWords = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        string sourceCommodity = postIsWords.Skip(postIsWords.Length - 1).ToString();
                        string destinationCommodity = preIsWords[2];

                        string[] aliases = postIsWords.Take(postIsWords.Length - 1).ToArray();
                        
                        StringBuilder sb = new StringBuilder();

                        //Create Roman Numeral from aliases
                        for (int i = 0; i < aliases.Length - 1; i++)
                        {
                                sb.Append(aliasMap.GetValueForAlias(aliases[i]));
                        }

                        double sourceCommodityPrice = commodityIndex.GetPriceByCommodity(sourceCommodity);
                        double destinationCommodityPrice = commodityIndex.GetPriceByCommodity(destinationCommodity);

                        //Convert Roman to Decimal
                        double? totalUnits = converter.ToDecimal(sb.ToString());
                        if (totalUnits.HasValue)
                        {
                                double totalSourceCommodity = sourceCommodityPrice * totalUnits.Value;
                                Console.WriteLine(String.Format("{0} is {1} {2}", parts[1], (totalSourceCommodity/destinationCommodityPrice), destinationCommodity));
                        }
                }

                public bool Match(string input)
                {
                        //Remove question mark
                        input = input.Substring(0, input.Length - 1);

                        bool isQuestion = (input.StartsWith("how many", StringComparison.OrdinalIgnoreCase));
                        if (!isQuestion) return false;

                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2) return false;

                        string[] preIsWords = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (preIsWords.Length < 3) return false;

                        string[] postIsWords = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (postIsWords.Length < 2) return false;

                        return helper.AreWordsValidCommodities(preIsWords.Skip(preIsWords.Length - 1).ToArray()) &&
                                helper.AreWordsValidCommodities(postIsWords.Skip(postIsWords.Length - 1).ToArray()) && 
                                helper.AreWordsValidAliases(postIsWords.Take(postIsWords.Length -1).ToArray());
                }
        }
}
