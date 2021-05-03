using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Payslip2
{
    /// <summary>
    /// Method creates a csv output for the payslip
    /// </summary>
    class CsvGenerator
    {
        public CsvGenerator()
        {
            Csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
        }

        public UserInput UploadedData { get; set; }
        
        private StringBuilder Csvcontent = new StringBuilder();

        private string  CsvPath = $"../../../csvOutput/new.csv";
        
        public void GenerateCsvManual(PayslipGenerator payslip)
        {
            Csvcontent.AppendLine($"{payslip.Name} {payslip.Surname},{payslip.PayPeriod},{payslip.GrossIncome},{payslip.IncomeTax},{payslip.NetIncome},{payslip.Super}");
            File.AppendAllText(CsvPath, Csvcontent.ToString());
        }  
        
        public void GenerateCsvUploaded(List<string> employees)
        {
            foreach(string employee in employees)
            {
                Csvcontent.AppendLine(employee);
            }
            File.AppendAllText(CsvPath, Csvcontent.ToString());
        }
    }
}
