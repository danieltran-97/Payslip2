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
        public readonly List<string> EmployeePaySlip = new List<string>();

        private readonly Payslip _payslipGenerator = new Payslip();
        
        public void CsvInput()
        {
            Console.Write("Please enter the csv file you would like to upload.  ");
            var csvFile = Console.ReadLine();

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
                    _payslipGenerator.Name = firstNameList[i];
                    _payslipGenerator.Surname = lastNameList[i];
                    _payslipGenerator.AnnualSalary = Convert.ToDecimal(annualSalaryList[i]);
                    _payslipGenerator.SuperRate = Convert.ToDecimal(superRateList[i].Replace("%",""));
                    _payslipGenerator.PaymentStartDate = paymentStartDateList[i];

                    Console.WriteLine(_payslipGenerator.PrintPaySlip());

                    StorePayslipData();
                }
            }
        }
        
        public void ManualInput()
        {

            Console.Write("Please input your name:  ");
            _payslipGenerator.Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            _payslipGenerator.Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            _payslipGenerator.AnnualSalary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            _payslipGenerator.SuperRate = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            _payslipGenerator.PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            _payslipGenerator.PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(_payslipGenerator.PrintPaySlip());

            StorePayslipData();
        }

        private void StorePayslipData()
        {
            EmployeePaySlip.Add($"{_payslipGenerator.Name} {_payslipGenerator.Surname},{_payslipGenerator.PayPeriod},{_payslipGenerator.GrossIncome},{_payslipGenerator.IncomeTax},{_payslipGenerator.NetIncome} , {_payslipGenerator.Super}");
        }
    }


}
