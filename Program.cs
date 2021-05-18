using System;

namespace Payslip2
{
    static class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the payslip generator!");
            
            GetValidInputFromConsole("Would you like to upload a csv file? (Please answer YES/NO): ");
            
        }

        private static void GetValidInputFromConsole(string input)
        {
            var uploadCsv = new UserInput();
            var csvExporter = new CsvExporter(uploadCsv);;
            
            var success = false;
            var answer = "";

            while (!success)
            {
                Console.Write(input);
                answer = Console.ReadLine().ToUpper();
                success = answer == "Y" || answer == "YES" || answer == "N" || answer == "NO" ;
            }
            
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
