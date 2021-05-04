using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Payslip2
{
    /// <summary>
    /// Method creates a csv output for the payslip
    /// </summary>
    class CsvExporter
    {
        public CsvExporter(UserInput uploadedData)
        {
            UploadedData = uploadedData;
            Csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
        }

        private UserInput UploadedData { get; set; }
        
        private StringBuilder Csvcontent = new StringBuilder();

        private string  CsvPath = $"../../../csvOutput/new.csv";

        public void GenerateCsvUploaded()
        {
            foreach(string employee in UploadedData.EmployeePaySlip)
            {
                Csvcontent.AppendLine(employee);
            }
            File.AppendAllText(CsvPath, Csvcontent.ToString());
        }
    }
}
