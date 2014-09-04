namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public class JsonManipulator
    {
        public void GenerateReports(IEnumerable<JsonReportViewModel> jsonReports)
        {
            ExportReports.CreateJsonReport(jsonReports);
        }
    }
}
