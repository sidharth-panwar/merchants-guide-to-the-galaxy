using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Shared
{
        /// <summary>
        /// This class stores mappings of commodities and their per unit prices.
        /// </summary>
        public class CommodityIndex
        {
                private Dictionary<string, double> commodityMap;

                public CommodityIndex()
                {
                        commodityMap = new Dictionary<string, double>();
                }

                public void AddCommodity(string name, double perUnitPrice)
                {
                        if (!commodityMap.ContainsKey(name)) commodityMap.Add(name, perUnitPrice);
                        else commodityMap[name] = perUnitPrice;
                }

                public double GetPriceByCommodity(string commodity)
                {
                        return commodityMap[commodity];
                }

                public bool Exists(string commodity)
                {
                        return commodityMap.ContainsKey(commodity);
                }
        }
}
