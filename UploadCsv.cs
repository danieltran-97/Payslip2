using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Payslip2
{
    /// <summary>
    /// Class inherits from GenerateSlip class.
    /// </summary>
    class UploadCsv : GenerateSlip, IUserInput, ICsvOutput
    {
        private string _csvFile;

        public void UserInput()
        {
            Console.Write("Please enter the csv file you would like to upload.  ");
                _csvFile = Console.ReadLine();
                
        }

        public List<string> ParseCsv()
        {
            var employeePaySlip = new List<string>();
            using(var reader = new StreamReader($"csv/{_csvFile}"))
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
                    Name = firstNameList[i];
                    Surname = lastNameList[i];
                    AnnualSalary = Convert.ToDouble(annualSalaryList[i]);
                    SuperRate = Convert.ToDouble(superRateList[i].Replace("%",""));
                    PaymentStartDate = paymentStartDateList[i];

                    Console.WriteLine(PrintPaySlip());
                    
                    employeePaySlip.Add($"{Name} {Surname},{PayPeriod()},{GrossIncome()},{IncomeTax()},{NetIncome()} , {Super()}");
                }
            }
            return employeePaySlip;
        }
        public void GenerateCsv()
        {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
            string csvPath = $"csvOutput/new.csv";
            foreach(string employee in ParseCsv())
            {
                csvcontent.AppendLine(employee);
            }
            File.AppendAllText(csvPath, csvcontent.ToString());
        }
    }
}

