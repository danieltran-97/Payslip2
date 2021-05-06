using System;

namespace Payslip2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var uploadCsv = new UserInput();
            var csvExporter = new CsvExporter(uploadCsv);;

            Console.WriteLine("Welcome to the payslip generator!");
            
            Console.Write("Would you like to upload a csv file? (Please answer YES/NO): ");
            var answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
                case "YES" or "Y":
                {
                    //If we want to upload CSV file
                    uploadCsv.CsvInput();
                    csvExporter.ExportCsv();
                    break;
                }
                case "NO" or "N":
                {
                    //If we want to manually enter data
                    uploadCsv.ManualInput();
                    csvExporter.ExportCsv();
                    break;
                }
                default:
                    Console.WriteLine("Answer is invalid");
                    break;
            }
        }
    }
}
