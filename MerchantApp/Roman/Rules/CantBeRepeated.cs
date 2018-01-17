using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Rules
{
        /// <summary>
        /// This rules is used in the Roman to Decimal conversion and it for non-repeatable Roman Numerals in the passed input.
        /// </summary>
        public class CantBeRepeated : IConversionRule
        {
                public bool Execute(string input)
                {
                        bool result = (input.Length < 2) || 
                                (input.Count(c => c == 'D') <= 1 && input.Count(c => c == 'L') <= 1 && input.Count(c => c == 'V') <= 1);
                        
                        if (!result) { Console.WriteLine("CantBeRepeated Rule has been violated"); }

                        return result;
                }
        }
}
