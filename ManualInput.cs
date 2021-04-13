using System;
using System.IO;
using System.Text;

namespace Payslip2
{
    /// <summary>
    /// Class inherits from GenerateSlip class
    /// </summary>
    class ManualInput : GenerateSlip, IUserInput, ICsvOutput
    {
        public void UserInput()
        {

            Console.Write("Please input your name:  ");
            Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            AnnualSalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            SuperRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(PrintPaySlip());
        }
        public void GenerateCsv()
        {
            var csvcontent = new StringBuilder();
            csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
            csvcontent.AppendLine($"{Name} {Surname},{PayPeriod()},{GrossIncome()},{IncomeTax()},{NetIncome()} , {Super()}");
            var csvPath = $"csvOutput/new.csv";
            File.AppendAllText(csvPath, csvcontent.ToString());
        }     
    }


}
