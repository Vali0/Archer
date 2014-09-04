namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.MySQL.Data;
    using TelerikKindergarten.ReportModels;

    public class MySqlManipulator
    {
        private TelerikKindergartenMySQLModel context;

        public MySqlManipulator(TelerikKindergartenMySQLModel mySqlContext)
        {
            this.context = mySqlContext;
        }

        public void AddJsonReports(IEnumerable<JsonReportViewModel> jsonReportsFromFiles)
        {
            this.context.Add(jsonReportsFromFiles);
            this.context.SaveChanges();
        }

        public IEnumerable<JsonReportViewModel> GetReports()
        {
            var reports = this.context.Reports.ToList();

            return reports;
        }
    }
}
