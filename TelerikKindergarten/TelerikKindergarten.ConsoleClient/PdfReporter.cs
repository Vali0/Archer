namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public class PdfManipulator
    {
        public void GenerateReport(IEnumerable<PdfReportViewModel> pdfReports)
        {
            ExportReports.CreatePdfReport(pdfReports);
        }
    }
}
