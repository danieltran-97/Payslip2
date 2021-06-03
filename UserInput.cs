using System;
using System.Collections.Generic;
using System.IO;

namespace Payslip2
{
    /// <summary>
    /// Class inherits from GenerateSlip class
    /// </summary>

    class UserInput
    {
        public readonly List<string> EmployeePayslipData = new List<string>();

        private readonly Payslip _payslipGenerator = new Payslip();

        public string UserInputChoice = string.Empty;
        
        public void ChooseUserInputMethod()
        {
            var success = false;
            
            while (!success)
            {
                Console.Write("Would you like to upload a csv file? (Please answer YES/NO): ");
                UserInputChoice = Console.ReadLine().ToUpper();
                success = UserInputChoice == "Y" || UserInputChoice == "YES" || UserInputChoice == "N" || UserInputChoice == "NO" ;
                
                if (!success)
                {
                    Console.WriteLine("Answer is invalid");
                }
            }
        }

        public void CsvInput()
        {
            var fileExists = false;
            var csvFile = String.Empty;
            
            while (!fileExists)
            {
                csvFile = GetStringFromConsole("Please enter the full path of the csv file you would like to upload.  ");
                fileExists = File.Exists(csvFile);
                Console.WriteLine("File not found");
            }
            
            var reader = new StreamReader(csvFile);
            using(reader)
            {
                var firstNameList = new List<string>();
                var lastNameList = new List<string>();
                var annualSalaryList = new List<string>();
                var superRateList = new List<string>();
                var paymentStartDateList = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    firstNameList.Add(values[0]);
                    lastNameList.Add(values[1]);
                    annualSalaryList.Add(values[2]);
                    superRateList.Add(values[3]);
                    paymentStartDateList.Add(values[4]);
                }
                
                for (var i = 1; i < firstNameList.Count; i++)
                {
                    _payslipGenerator.Name = firstNameList[i];
                    _payslipGenerator.Surname = lastNameList[i];
                    _payslipGenerator.AnnualSalary = Convert.ToDecimal(annualSalaryList[i]);
                    _payslipGenerator.SuperRate = Convert.ToDecimal(superRateList[i].Replace("%",""));
                    _payslipGenerator.PaymentStartDate = paymentStartDateList[i];

                    DisplayPayslip();
                    
                    StorePayslipData();
                }
            }
        }

        public void ManualInput()
        {

            _payslipGenerator.Name = GetStringFromConsole("Please input your name:  ");
            _payslipGenerator.Surname = GetStringFromConsole("Please input your surname:  ");
            _payslipGenerator.AnnualSalary = GetDecimalFromConsole("Please enter your annual salary:  ");
            _payslipGenerator.SuperRate = GetDecimalFromConsole("Please enter your super rate:  ");
            _payslipGenerator.PaymentStartDate = GetStringFromConsole("Please enter your payment start date:  ");
            _payslipGenerator.PaymentEndDate = GetStringFromConsole("Please enter your payment end date:  ");
            Console.WriteLine(" \n Your payslip has been generated: \n");

            DisplayPayslip();

            StorePayslipData();
        }

        private string GetStringFromConsole(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        private decimal GetDecimalFromConsole(string input)
        {
            var success = false;
            decimal result = 0;
            while (!success)
            {
                Console.Write(input);
                var temp = Console.ReadLine();
                success = Decimal.TryParse(temp, out result);
            }
            return result;
        }

        private void DisplayPayslip()
        {
            Console.WriteLine(_payslipGenerator.PrintPaySlip());
        }

        private void StorePayslipData()
        {
            EmployeePayslipData.Add($"{_payslipGenerator.Name} {_payslipGenerator.Surname},{_payslipGenerator.PayPeriod},{_payslipGenerator.GrossIncome},{_payslipGenerator.IncomeTax},{_payslipGenerator.NetIncome} , {_payslipGenerator.Super}");
        }
    }
}
