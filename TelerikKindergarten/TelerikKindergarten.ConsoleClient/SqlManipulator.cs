namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.SQL.Model;

    public static class SqlManipulator
    {
        public static void AddExcelReports(IEnumerable<ExcelReportViewModel> reports, ITelerikKindergartenData context)
        {
            foreach (var report in reports)
            {
                // title, producer, product
                string assetName = report.Product;
                var assets = context.AssetTypes.SearchFor(x => x.Name == report.Product);
                if (assets.Count() == 0)
                {
                    var newAssetType = new AssetType();
                    newAssetType.Name = report.Product;
                    context.AssetTypes.Add(newAssetType);
                    context.SaveChanges();
                }

                var asset = new Asset();
                var assetType = context.AssetTypes.SearchFor(x => x.Name == assetName).First();
                asset.AssetType = assetType;
            }
        }

        public static IEnumerable<PdfReportViewModel> GetPdfReportsData(ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<XmlReportViewModel> GetXmlReportsData(ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<JSONReportViewModel> GetJsonReportsData(ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }

        public static void AddXmlReports(IEnumerable<XmlReportViewModel> loadedXmlReports, ITelerikKindergartenData sqlContext)
        {
            throw new NotImplementedException();
        }
    }
}
