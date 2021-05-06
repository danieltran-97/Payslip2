using System.IO;
using System.Text;

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

        private UserInput UploadedData { get; }

        private static readonly int Count = Directory.GetFiles("../../../csvOutput").Length;
        
        private readonly StringBuilder _csvcontent = new StringBuilder();

        private readonly string _csvPath = Count == 0 ?  "../../../csvOutput/Payslip.csv" : $"../../../csvOutput/Payslip{Count + 1}.csv";

        public void ExportCsv()
        {
            foreach(var employee in UploadedData.EmployeePaySlip)
            {
                _csvcontent.AppendLine(employee);
            }
            File.AppendAllText(_csvPath, _csvcontent.ToString());
        }
    }
}
