using System;
using System.IO;
using System.Text;

namespace Payslip2
{
    /// <summary>
    ///  Creates a csv output for the payslip
    /// </summary>
    class CsvExporter
    {
        public CsvExporter(UserInput uploadedData)
        {
            UploadedData = uploadedData;
            _csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
        }

        private UserInput UploadedData { get; }
        
        private readonly StringBuilder _csvcontent = new StringBuilder();
        
        public void ExportCsv()
        {
            var filename = $"Payslip-{DateTime.Now:yyyy-MM-dd 'at' HH.mm.ss}.csv";
            var path = $"../../../../Downloads/{filename}";
            
            foreach(var employee in UploadedData.EmployeePayslipData)
            {
                _csvcontent.AppendLine(employee);
            }
            File.AppendAllText(path, _csvcontent.ToString());
        }
    }
}
