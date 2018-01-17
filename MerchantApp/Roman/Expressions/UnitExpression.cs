using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Expressions
{
        /// <summary>
        /// This class checks for and parses unit expressions. For e.g.,
        /// pish pish Iron is 3910 Credits
        /// </summary>
        public class UnitExpression : IExpression
        {
                private AliasMapper aliasMap;
                private CommodityIndex commodityIndex;
                private IDecimalConverter converter;
                private ExpressionValidationHelper helper;

                public UnitExpression(CommodityIndex commodityIndex, AliasMapper aliasMap, IDecimalConverter converter, ExpressionValidationHelper helper)
                {
                        this.commodityIndex = commodityIndex;
                        this.aliasMap = aliasMap;
                        this.converter = converter;
                        this.helper = helper;
                }

                public void Execute(string input)
                {
                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        string[] wordsInFirstPart = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] wordsInSecondPart = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        double decimalPrice = 0;
                        Double.TryParse(wordsInSecondPart[0], out decimalPrice);

                        string commodity = wordsInFirstPart[wordsInFirstPart.Length - 1];
                        string aliasValue = string.Empty;

                        //Create Roman Numeral from aliases
                        StringBuilder sb = new StringBuilder();

                        for (int i=0; i<wordsInFirstPart.Length-1; i++)
                        {
                                sb.Append(aliasMap.GetValueForAlias(wordsInFirstPart[i]));
                        }

                        //Convert Roman to decimal
                        double? totalUnits = converter.ToDecimal(sb.ToString());

                        //Calculate and store per unit price of commodity
                        if (totalUnits.HasValue) commodityIndex.AddCommodity(commodity, decimalPrice / totalUnits.Value);
                        else Console.WriteLine("Error occurred while calculating commodity price");
                }

                public bool Match(string input)
                {
                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2) return false;

                        string[] wordsInFirstPart = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] wordsInSecondPart = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        double output;

                        return input.EndsWith("credits", StringComparison.OrdinalIgnoreCase) && 
                                !input.StartsWith("how many", StringComparison.OrdinalIgnoreCase) && parts.Length == 2 && 
                                wordsInSecondPart.Length == 2 && Double.TryParse(wordsInSecondPart[0], out output) && helper.AreWordsValidAliases(wordsInFirstPart.Take(wordsInFirstPart.Length - 1).ToArray());
                }
        }
}
