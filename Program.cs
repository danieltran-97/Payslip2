using System;

namespace Payslip2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the payslip generator!");
            
            Console.Write("Would you like to upload a csv file? (Please answer YES/NO): ");
            var answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
                case "YES" or "Y":
                {
                    //If we want to upload CSV file
                    var uploadCsvFile = new UploadCsv();
                    uploadCsvFile.UserInput();
                    uploadCsvFile.GenerateCsv();
                    break;
                }
                case "NO" or "N":
                {
                    //If we want to manually enter data
                    var manualEntry = new ManualInput();
                    manualEntry.UserInput();
                    manualEntry.GenerateCsv();
                    break;
                }
                default:
                    Console.WriteLine("Answer is invalid");
                    break;
            }
        }
    }
}
