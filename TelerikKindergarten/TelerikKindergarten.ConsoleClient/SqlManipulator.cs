namespace TelerikKindergarten.ConsoleClient
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikKindergarten.Data;
using TelerikKindergarten.ReportModels;

    public static class SqlManipulator
    {
        public static void AddExcelReports(IEnumerable<ExcelReportViewModel> reports, ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<PdfReportViewModel> GetPdfReportsData(ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }
    }
}
