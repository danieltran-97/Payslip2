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
            _csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
        }

        private UserInput UploadedData { get; set; }

        private static int _count = Directory.GetFiles("../../../csvOutput").Length;
        
        private readonly StringBuilder _csvcontent = new StringBuilder();

        private readonly string _csvPath = _count == 0 ?  "../../../csvOutput/Payslip.csv" : $"../../../csvOutput/Payslip{_count + 1}.csv";

        public void GenerateCsvUploaded()
        {
            foreach(string employee in UploadedData.EmployeePaySlip)
            {
                _csvcontent.AppendLine(employee);
            }
            File.AppendAllText(_csvPath, _csvcontent.ToString());
        }
    }
}
