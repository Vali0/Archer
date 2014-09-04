namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public static class XmlManipulator
    {
        public static void GenerateReport(IEnumerable<XmlReportViewModel> xmlReports)
        {
            // TODO: Add GenerateReport functionality for XmlManipulator
            throw new NotImplementedException();
        }

        public static IEnumerable<XmlReportViewModel> LoadReportsFromFiles()
        {
            return ImportReports.GetXmlFromFile();
        }
    }
}
