using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Rules
{
        /// <summary>
        /// This rules is used in the Roman to Decimal conversion and it checks that 2 chars are not subtracted at once from a larger numeral.
        /// </summary>
        public class SingleSubtraction : IConversionRule
        {
                public bool Execute(string input)
                {
                        if (input.Length < 3) return true;

                        for (int i=input.Length-1; i>=2; i--)
                        {
                                if (Roman.IsSmaller(input[i-1].ToString(), input[i].ToString()) &&
                                        Roman.IsSmaller(input[i-2].ToString(), input[i].ToString()))
                                {
                                        Console.WriteLine("SingleSubtraction Rule has been violated");
                                        return false;
                                }
                        }

                        return true;
                }
        }
}
