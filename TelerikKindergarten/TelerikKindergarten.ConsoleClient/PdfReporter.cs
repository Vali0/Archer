namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public static class PdfReporter
    {
        public static void GenerateReport(IEnumerable<PdfReportViewModel> pdfReports)
        {
            ExportReports.CreatePdfReport(pdfReports);
        }
    }
}
