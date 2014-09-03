namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public static class ExcelManipulator
    {
        public static IEnumerable<ExcelReportViewModel> Import()
        {
            return ImportReports.GetExcelReports();
        }

        public static void Export()
        {
            
        }
    }
}
