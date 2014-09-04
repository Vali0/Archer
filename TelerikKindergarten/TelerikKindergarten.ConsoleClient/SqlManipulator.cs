﻿namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.Data;
    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.SQL.Model;

    public static class SqlManipulator
    {
        public static void AddExcelReports(IEnumerable<ExcelReportViewModel> reports, ITelerikKindergartenData context)
        {
            foreach (var report in reports)
            {
                var newAsset = new Asset();
                newAsset.AssetType = context.AssetTypes.SearchFor(x => x.Name == report.Product).First();
                newAsset.Department = context.Departments.SearchFor(x => x.Name == report.Department).First();
                newAsset.Value = report.TotalPrice;

                context.Assets.Add(newAsset);
            }

            context.SaveChanges();
        }

        public static IEnumerable<PdfReportViewModel> GetPdfReportsData(ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<XmlReportViewModel> GetXmlReportsData(ITelerikKindergartenData context)
        {
            //TODO : Check if this is correct. XmlReportViewModel
            return context.Reports.All();
        }

        public static IEnumerable<JsonReportViewModel> GetJsonReportsData(ITelerikKindergartenData context)
        {
            throw new NotImplementedException();
        }

        public static void AddXmlReports(IEnumerable<XmlReportViewModel> loadedXmlReports, ITelerikKindergartenData sqlContext)
        {
            //TODO : Check if this is correct. XmlReportViewModel
            foreach (var report in loadedXmlReports)
	        {
                sqlContext.Reports.Add(report);
	        }

            sqlContext.SaveChanges();
        }
    }
}
