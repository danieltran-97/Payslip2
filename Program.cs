using System;

namespace Payslip2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var userInput = new UserInput();
            
            Console.WriteLine("Welcome to the payslip generator!");
            //Choose whether we want to upload a csv or manually input data
            var inputMethodChoice = userInput.ChooseUserInputMethod();
            
            switch (inputMethodChoice)
            {
                case "YES" or "Y":
                {
                    //If we want to upload CSV file
                    userInput.CsvInput();
                    CsvExporter.ExportCsv(userInput.EmployeePayslipData);
                    break;
                }
                case "NO" or "N":
                {
                    //If we want to manually enter data
                    userInput.ManualInput();
                    CsvExporter.ExportCsv(userInput.EmployeePayslipData);
                    break;
                }
            }
        }
    }
}
