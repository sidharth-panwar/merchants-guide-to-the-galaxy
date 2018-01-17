using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Shared
{
        /// <summary>
        /// This interface should be implemented by all converters that convert from a source number system to decimals.
        /// </summary>
        public interface IDecimalConverter
        {
                double? ToDecimal(string input);
        }
}
