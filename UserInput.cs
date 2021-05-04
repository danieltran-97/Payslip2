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

        private Payslip PayslipGenerator = new Payslip();
        
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
                    PayslipGenerator.Name = firstNameList[i];
                    PayslipGenerator.Surname = lastNameList[i];
                    PayslipGenerator.AnnualSalary = Convert.ToDecimal(annualSalaryList[i]);
                    PayslipGenerator.SuperRate = Convert.ToDecimal(superRateList[i].Replace("%",""));
                    PayslipGenerator.PaymentStartDate = paymentStartDateList[i];

                    Console.WriteLine(PayslipGenerator.PrintPaySlip());

                    StorePayslipData();
                }
            }
        }
        
        public void ManualInput()
        {

            Console.Write("Please input your name:  ");
            PayslipGenerator.Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            PayslipGenerator.Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            PayslipGenerator.AnnualSalary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            PayslipGenerator.SuperRate = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            PayslipGenerator.PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            PayslipGenerator.PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(PayslipGenerator.PrintPaySlip());

            StorePayslipData();
        }

        private void StorePayslipData()
        {
            EmployeePaySlip.Add($"{PayslipGenerator.Name} {PayslipGenerator.Surname},{PayslipGenerator.PayPeriod},{PayslipGenerator.GrossIncome},{PayslipGenerator.IncomeTax},{PayslipGenerator.NetIncome} , {PayslipGenerator.Super}");
        }
    }


}
