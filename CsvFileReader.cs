using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Insure_Assessment
{
    public class CsvFileReader
    {
        public static List<ParlourShopModel> ReadData(string filePath)
        {
            var shopData = new List<ParlourShopModel>();
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = new ParlourShopModel
                {
                    Date = DateTime.Parse(csv.GetField("Date")),
                    SKU = csv.GetField("SKU"),
                    UnitPrice = decimal.Parse(csv.GetField("Unit Price")),
                    Quantity = int.Parse(csv.GetField("Quantity")),
                    TotalPrice = decimal.Parse(csv.GetField("Total Price"))
                };
                shopData.Add(record);
            }
            return shopData;
        }
    }
}
