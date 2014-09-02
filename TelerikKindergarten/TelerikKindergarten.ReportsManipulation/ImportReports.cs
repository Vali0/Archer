﻿namespace TelerikKindergarten.ReportsManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using TelerikKindergarten.ReportModels;

    public class ImportReports
    {
        /// <summary>
        /// Gets data from zipped Excel data
        /// </summary>
        /// <param name="pathToZipFile">Location of the .zip file</param>
        /// <param name="zipNameAndExtension">Only the name and extension of the file. 
        /// NOTE: Works only for .zip files</param>
        /// <returns>Returns IEnumerable with objects that hold the necessary data from the reports</returns>
        public static IEnumerable<ExcelReportViewModel> GetExcelReports(string pathToZipFile, string zipNameAndExtension)
        {
            ExtractZipReports(pathToZipFile, zipNameAndExtension);

            var allReportsFromExcel = new List<ExcelReportViewModel>();

            string[] fileNames = Directory.GetFiles(pathToZipFile, "*.xls", SearchOption.AllDirectories);

            for (int i = 0; i < fileNames.Length; i++)
            {
                var dataFromSingleFile = ReadExcelFile(fileNames[i]);

                allReportsFromExcel.AddRange(dataFromSingleFile);
            }
            
            return allReportsFromExcel;
        }

        private static void ExtractZipReports(string extractPath, string zipName)
        {
            var pathToTheZip = Path.Combine(extractPath, zipName);
            using (ZipArchive archive = ZipFile.OpenRead(pathToTheZip))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                    }
                    else
                    {
                        Directory.CreateDirectory(Path.Combine(extractPath, entry.FullName));
                    }
                }
            }
        }

        /// <summary>
        /// Returns the content of a single Excel file as a collection of the read rows
        /// </summary>
        /// <param name="filePath">path of the file to be read</param>
        /// <returns>Returns IEnumerable with objects that hold the necessary data from a single .xls file</returns>
        private static IEnumerable<ExcelReportViewModel> ReadExcelFile(string filePath)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + @"; Extended Properties=""Excel 12.0 Xml;HDR=YES;""";

            OleDbConnection xlsConnection = new OleDbConnection(connectionString);
            xlsConnection.Open();

            var fileDataFromReport = new List<ExcelReportViewModel>();
            using (xlsConnection)
            {
                var dataTable = new DataTable();
                var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", xlsConnection);
                adapter.Fill(dataTable);

                string title = dataTable.Rows[0].ItemArray[0].ToString();

                for (int i = 2; i < dataTable.Rows.Count - 1; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    string product = row.ItemArray[0].ToString();
                    string producer = row.ItemArray[1].ToString();

                    fileDataFromReport.Add(new ExcelReportViewModel
                    {
                        InvoiceTitle = title,
                        Producer = producer,
                        Product = product
                    });
                }
            }

            return fileDataFromReport;
        }

        public static List<XmlReportViewModel> ReadXML(string filePath)
        {
            var collection = new List<XmlReportViewModel>();
            var serializer = new XmlSerializer(collection.GetType());

            using (var reader = new StreamReader(filePath))
            {
                return serializer.Deserialize(reader) as List<XmlReportViewModel>;
            }
        }

    }
}