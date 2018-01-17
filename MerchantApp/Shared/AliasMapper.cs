using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Shared
{
        /// <summary>
        /// This class stores a mapping of all the aliases and their corresponding Roman Numeral.
        /// </summary>
        public class AliasMapper
        {
                private Dictionary<string, string> aliasMap;

                public AliasMapper()
                {
                        aliasMap = new Dictionary<string, string>();
                }

                public void AddAlias(string alias, string value)
                {
                        if (!aliasMap.ContainsKey(alias)) aliasMap.Add(alias, value);
                        else aliasMap[alias] = value;
                }

                public string GetValueForAlias(string alias)
                {
                        return aliasMap[alias];
                }

                public bool Exists(string alias)
                {
                        return aliasMap.ContainsKey(alias);
                }
        }
}
