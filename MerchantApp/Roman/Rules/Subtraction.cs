using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman.Rules
{
        /// <summary>
        /// This rules is used in the Roman to Decimal conversion and it checks the subtraction related rules for the conversion.
        /// </summary>
        public class Subtraction : IConversionRule
        {
                public bool Execute(string input)
                {
                        bool result = (input.Length < 2) ||
                                !(input.Contains("IL") || input.Contains("IC") || input.Contains("ID") || input.Contains("IM") ||
                                input.Contains("XD") || input.Contains("XM"));

                        if (!result) { Console.WriteLine("Subtraction Rule has been violated"); }

                        return result;
                }
        }
}
