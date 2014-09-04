namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public class ExcelManipulator
    {
        public IEnumerable<ExcelReportViewModel> Import()
        {
            return ImportReports.GetExcelReports();
        }

        public void ExportReports(IEnumerable<JsonReportViewModel> jsonReports, IEnumerable<FoodReportViewModel> foodReport)
        {
            // TODO: Add ExportReports functionality for final excel report.
            throw new NotImplementedException();
        }
    }
}
