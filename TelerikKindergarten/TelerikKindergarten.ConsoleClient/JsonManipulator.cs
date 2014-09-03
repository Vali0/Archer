namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public static class JsonManipulator
    {
        public static void GenerateReports(IEnumerable<JsonReportViewModel> jsonReports)
        {
            ExportReports.CreateJsonReport(jsonReports);
        }

        public static IEnumerable<JsonReportViewModel> GetJsonReportsFromFiles()
        {
            throw new NotImplementedException();
        }
    }
}
