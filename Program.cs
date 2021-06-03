using System;

namespace Payslip2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var userInput = new UserInput();
            var csvExporter = new CsvExporter(userInput);
            
            Console.WriteLine("Welcome to the payslip generator!");
            //Choose whether we want to upload a csv or manually input data
            userInput.ChooseUserInputMethod();
            
            switch (userInput.UserInputChoice)
            {
                case "YES" or "Y":
                {
                    //If we want to upload CSV file
                    userInput.CsvInput();
                    csvExporter.ExportCsv();
                    break;
                }
                case "NO" or "N":
                {
                    //If we want to manually enter data
                    userInput.ManualInput();
                    csvExporter.ExportCsv();
                    break;
                }
            }
        }
    }
}
