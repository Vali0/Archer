namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.Data;
    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.SQL.Model;

    public class SqlManipulator
    {
        private ITelerikKindergartenData context;

        public SqlManipulator(ITelerikKindergartenData sqlContext)
        {
            this.context = sqlContext;
        }

        public void AddExcelReports(IEnumerable<ExcelReportViewModel> reports)
        {
            foreach (var report in reports)
            {
                var newAsset = new Asset();
                newAsset.AssetType = this.context.AssetTypes.SearchFor(x => x.Name == report.Product).First();
                newAsset.Department = this.context.Departments.SearchFor(x => x.Name == report.Department).First();
                newAsset.Value = report.TotalPrice;

                this.context.Assets.Add(newAsset);
            }

            this.context.SaveChanges();
        }

        public IEnumerable<PdfReportViewModel> GetPdfReportsData()
        {
            // TODO: Add GetPdfReportsData functionality for SqlManipulator
            throw new NotImplementedException();
        }

        public IEnumerable<XmlReportViewModel> GetXmlReportsData()
        {
            //TODO : Check if this is correct. XmlReportViewModel
            return this.context.Reports.All();
        }

        public IEnumerable<JsonReportViewModel> GetJsonReportsData()
        {
            // TODO: Add GetJsonReportsData functionality for SqlManipulator
            throw new NotImplementedException();
        }

        public void AddXmlReports(IEnumerable<XmlReportViewModel> loadedXmlReports)
        {
            //TODO : Check if this is correct. XmlReportViewModel
            foreach (var report in loadedXmlReports)
	        {
                this.context.Reports.Add(report);
	        }

            this.context.SaveChanges();
        }
    }
}
