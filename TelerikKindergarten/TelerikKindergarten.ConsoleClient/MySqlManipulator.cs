namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.MySQL.Data;
    using TelerikKindergarten.ReportModels;

    public static class MySqlManipulator
    {
        public static void AddJsonReports(IEnumerable<JsonReportViewModel> jsonReportsFromFiles, TelerikKindergartenMySQLModel context)
        {
            context.Add(jsonReportsFromFiles);
            context.SaveChanges();
        }

        public static IEnumerable<JsonReportViewModel> GetReports(TelerikKindergartenMySQLModel context)
        {
            var reports = context.Reports.ToList();

            return reports;
        }
    }
}
