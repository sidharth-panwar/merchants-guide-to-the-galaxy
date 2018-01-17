using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Shared
{
        /// <summary>
        /// This interface should be implemented by all the rules that needs to be satisfied before a conversion 
        /// from one numer system to another can happen.
        /// </summary>
        public interface IConversionRule
        {
                bool Execute(string input);
        }
}
