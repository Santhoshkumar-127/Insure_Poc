using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insure_Assessment
{
    public class ParlourDataCalculation
    {
        public static decimal GetTotalData(List<ParlourShopModel> totalData)
        {
            decimal total = 0;
            foreach (var data in totalData)
            {
                total += data.TotalPrice;
            }
            return total;
        }

        public static Dictionary<int, decimal> GetMonthData(List<ParlourShopModel> monthData)
        {
            var monthValues = new Dictionary<int, decimal>();
            foreach (var data in monthData)
            {
                int month = data.Date.Month;
                if (!monthValues.ContainsKey(month))
                {
                    monthValues[month] = 0;
                }
                monthValues[month] += data.TotalPrice;
            }
            return monthValues;
        }

        public static Dictionary<int, string> GetPopularItem(List<ParlourShopModel> popularItem)
        {
            var monthlyItem = new Dictionary<int, Dictionary<string, int>>();
            foreach (var data in popularItem)
            {
                int month = data.Date.Month;
                if (!monthlyItem.ContainsKey(month))
                {
                    monthlyItem[month] = new Dictionary<string, int>();
                }
                if (!monthlyItem[month].ContainsKey(data.SKU))
                {
                    monthlyItem[month][data.SKU] = 0;
                }
                monthlyItem[month][data.SKU] += data.Quantity;
            }
            var mostPopularItems = new Dictionary<int, string>();
            foreach (var month in monthlyItem.Keys)
            {
                string top = "";
                int maxQuantity = 0;
                foreach (var item in monthlyItem[month])
                {
                    if (item.Value > maxQuantity)
                    {
                        maxQuantity = item.Value;
                        top = item.Key;
                    }
                }
                mostPopularItems[month] = top;
            }
            return mostPopularItems;
        }

        public static Dictionary<int, string> GetTopRevenue(List<ParlourShopModel> topRevenue)
        {
            var monthlyRevenue = new Dictionary<int, Dictionary<string, decimal>>();
            foreach (var data in topRevenue)
            {
                int month = data.Date.Month;
                if (!monthlyRevenue.ContainsKey(month))
                {
                    monthlyRevenue[month] = new Dictionary<string, decimal>();
                }
                if (!monthlyRevenue[month].ContainsKey(data.SKU))
                {
                    monthlyRevenue[month][data.SKU] = 0;
                }
                monthlyRevenue[month][data.SKU] += data.TotalPrice;
            }
            var topRevenueItem = new Dictionary<int, string>();
            foreach (var month in monthlyRevenue.Keys)
            {
                string topItem = "";
                decimal maxRevenue = 0;
                foreach (var item in monthlyRevenue[month])
                {
                    if (item.Value > maxRevenue)
                    {
                        maxRevenue = item.Value;
                        topItem = item.Key;
                    }
                }
                topRevenueItem[month] = topItem;
            }
            return topRevenueItem;
        }        
    }
}
