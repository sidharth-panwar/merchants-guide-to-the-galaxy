using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Expressions
{
        /// <summary>
        /// This class checks for and parses alias question expressions. For e.g.,
        /// How much is glob glob?
        /// </summary>
        public class AliasQuestionExpression : IExpression
        {
                private AliasMapper aliasMap;
                private IDecimalConverter converter;
                private ExpressionValidationHelper helper;

                public AliasQuestionExpression(AliasMapper aliasMap, IDecimalConverter converter, ExpressionValidationHelper helper)
                {
                        this.aliasMap = aliasMap;
                        this.converter = converter;
                        this.helper = helper;
                }

                public void Execute(string input)
                {
                        //Remove question mark
                        input = input.Substring(0, input.Length - 1);

                        StringBuilder sb = new StringBuilder();
                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word in words)
                        {
                                if (!aliasMap.Exists(word))
                                {
                                        Console.WriteLine(String.Format("Error while processing this input: {0}", input));
                                        return;
                                }
                                sb.Append(aliasMap.GetValueForAlias(word));
                        }

                        Console.WriteLine(String.Format("{0} is {1}", parts[1], converter.ToDecimal(sb.ToString())));
                }
                
                public bool Match(string input)
                {
                        //Remove question mark from the last alias
                        input = input.Substring(0, input.Length - 1);

                        bool isQuestion = (input.StartsWith("how much", StringComparison.OrdinalIgnoreCase));
                        if (!isQuestion) return false;

                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2) return false;

                        string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length < 1) return false;

                        return helper.AreWordsValidAliases(words);
                }
        }
}
