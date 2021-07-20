using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Payslip2
{
    /// <summary>
    ///  Creates a csv output for the payslip
    /// </summary>
    static class CsvExporter
    {
        public static void ExportCsv(List<string> employeePayslip)
        {
            var csvcontent = new StringBuilder();
            
            csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
            
            var filename = $"Payslip-{DateTime.Now:yyyy-MM-dd 'at' HH.mm.ss}.csv";
            var path = $"../../../../Downloads/{filename}";
            
            foreach(var employee in employeePayslip)
            {
                csvcontent.AppendLine(employee);
            }
            File.AppendAllText(path, csvcontent.ToString());
        }
    }
}
