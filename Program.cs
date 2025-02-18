using Insure_Assessment;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "sample_data.csv");
        string outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "output_report.json");

        if (!File.Exists(inputFile))
        {
            //{Path.GetFullPath(inputFile)} - Using this to get input file path
            Console.WriteLine($"Error: File not found");
            return;
        }
        List<ParlourShopModel> shopData = CsvFileReader.ReadData(inputFile);
        var report = new
        {
            Total_Amount = ParlourDataCalculation.GetTotalData(shopData),
            Month_Wise_Amont = ParlourDataCalculation.GetMonthData(shopData),
            Most_Popular_Item = ParlourDataCalculation.GetPopularItem(shopData),
            Top_Revenue = ParlourDataCalculation.GetTopRevenue(shopData),
        };
        ParlourDataSave.WriteReport(outputFile, report);
        Console.WriteLine($"Output File Created: {outputFile}"); //Check Output File Path here
    }
}
