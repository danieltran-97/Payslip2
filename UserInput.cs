using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Payslip2
{
    /// <summary>
    /// Class inherits from GenerateSlip class
    /// </summary>

    class UserInput
    {
        public List<string> EmployeePaySlip = new List<string>();
        public List<string> CsvInput()
        {
            Console.Write("Please enter the csv file you would like to upload.  ");
            var csvFile = Console.ReadLine();
            
            var payslipGenerator = new PayslipGenerator();
            
            using(var reader = new StreamReader($"../../../csv/{csvFile}"))
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
                    payslipGenerator.Name = firstNameList[i];
                    payslipGenerator.Surname = lastNameList[i];
                    payslipGenerator.AnnualSalary = Convert.ToDecimal(annualSalaryList[i]);
                    payslipGenerator.SuperRate = Convert.ToDecimal(superRateList[i].Replace("%",""));
                    payslipGenerator.PaymentStartDate = paymentStartDateList[i];

                    Console.WriteLine(payslipGenerator.PrintPaySlip());
                    
                    EmployeePaySlip.Add($"{payslipGenerator.Name} {payslipGenerator.Surname},{payslipGenerator.PayPeriod},{payslipGenerator.GrossIncome},{payslipGenerator.IncomeTax},{payslipGenerator.NetIncome} , {payslipGenerator.Super}");
                }
            }
            return EmployeePaySlip;
        }
        
        public void ManualInput()
        {
            var payslipGenerator = new PayslipGenerator();

            Console.Write("Please input your name:  ");
            payslipGenerator.Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            payslipGenerator.Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            payslipGenerator.AnnualSalary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            payslipGenerator.SuperRate = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            payslipGenerator.PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            payslipGenerator.PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(payslipGenerator.PrintPaySlip());
        }
    }


}
