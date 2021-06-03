using System;
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
        public CsvExporter(List<string> employeePayslipList)
        {
            EmployeePayslipList = employeePayslipList;
            _csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
        }

        private List<string> EmployeePayslipList { get; }
        
        private readonly StringBuilder _csvcontent = new StringBuilder();
        
        public void ExportCsv()
        {
            var filename = $"Payslip-{DateTime.UtcNow:yyyy-MM-dd-HH:mm}.csv";
            var path = $"../../../../Downloads/{filename}";
            
            foreach(var employee in EmployeePayslipList)
            {
                _csvcontent.AppendLine(employee);
            }
            File.AppendAllText(path, _csvcontent.ToString());
        }
    }
}
