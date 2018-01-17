using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Shared
{
        /// <summary>
        /// This interface should be implemented by all classes that define a type of expression that can be parsed by 
        /// this program.
        /// </summary>
        public interface IExpression
        {
                bool Match(string input);
                void Execute(string input);
        }
}
