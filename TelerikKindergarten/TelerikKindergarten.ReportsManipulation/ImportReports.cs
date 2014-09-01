namespace TelerikKindergarten.ReportsManipulation
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
        public static void ExtractZipReports()
        {
            string zipPath = @"Excel import reports.zip";
            string extractPath = @"extract";

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
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

        public static void ReadExcelFiles(string filePath)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + @"; Extended Properties=""Excel 12.0 Xml;HDR=YES;""";

            OleDbConnection xlsConnection = new OleDbConnection(connectionString);
            xlsConnection.Open();

            using (xlsConnection)
            {
                var dataTable = new DataTable();
                var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", xlsConnection);
                adapter.Fill(dataTable);

                string title = dataTable.Rows[0].ItemArray[0].ToString();
                Console.WriteLine(title);

                for (int i = 2; i < dataTable.Rows.Count - 1; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    string product = row.ItemArray[0].ToString();
                    string producer = row.ItemArray[1].ToString();
                    Console.WriteLine(product + " -> " + producer);
                }
            }

        }

        public List<XmlReportViewModel> ReadXML(string filePath)
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