using MerchantApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Roman
{
    public class ExpressionValidationHelper
    {
                private AliasMapper aliasMap;
                private CommodityIndex commodityIndex;

                public ExpressionValidationHelper(AliasMapper aliasMap, CommodityIndex commodityIndex)
                {
                        this.aliasMap = aliasMap;
                        this.commodityIndex = commodityIndex;
                }

                public bool AreWordsValidAliases(string[] words)
                {
                        foreach (string word in words) { if (!aliasMap.Exists(word)) { return false; } }
                        return true;
                }

                public bool AreWordsValidCommodities(string[] words)
                {
                        foreach (string word in words) { if (!commodityIndex.Exists(word)) { return false; } }
                        return true;
                }
        }
}
