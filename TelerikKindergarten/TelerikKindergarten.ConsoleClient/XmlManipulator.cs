namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.ReportsManipulation;

    public class XmlManipulator
    {
        public void GenerateReport(IEnumerable<XmlReportViewModel> xmlReports)
        {
            // TODO: Add GenerateReport functionality for XmlManipulator
            throw new NotImplementedException();
        }

        public IEnumerable<XmlReportViewModel> LoadReportsFromFiles()
        {
            return ImportReports.GetXmlFromFile();
        }
    }
}
