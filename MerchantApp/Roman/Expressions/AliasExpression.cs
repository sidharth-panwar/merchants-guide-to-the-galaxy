using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Expressions
{
        /// <summary>
        /// This class checks for and parses alias expressions. For e.g.,
        /// glob is I
        /// </summary>
        public class AliasExpression : IExpression
        {
                private AliasMapper aliasMap;

                public AliasExpression(AliasMapper aliasMap)
                {
                        this.aliasMap = aliasMap;
                }

                public void Execute(string input)
                {
                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                        
                        string roman = parts[1];
                        aliasMap.AddAlias(parts[0], parts[1]);
                }

                public bool Match(string input)
                {
                        string romanAlphabet = Roman.GetAlphabet();
                        string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length != 2) return false;

                        string roman = parts[1];
                        bool found = false;

                        for(int i=0; i<romanAlphabet.Length; i++)
                        {
                                if (String.Equals(roman, romanAlphabet[i].ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                        found = true;
                                        break;
                                }
                        }

                        return found;
                }
        }
}
