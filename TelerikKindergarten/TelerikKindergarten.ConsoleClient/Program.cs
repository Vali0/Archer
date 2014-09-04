namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.SQL;
    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.MySQL.Data;
    using TelerikKindergarten.SQLite.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Fix after all functionality has been fixed.
            //Mongodb seeding
            string mongoConnectionString = "mongodb://localhost";
            //Get data from the base.
            var client = new MongoClient(mongoConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("TelerikKindergarten");
            using (var mySqlContext = new TelerikKindergartenMySQLModel())
            {
                var schemaHandler = mySqlContext.GetSchemaHandler();
                MySqlUtilities.EnsureDB(schemaHandler);

                //SeedData.SeedMongoDb(mongoConnectionString); // Uncomment to seed mongodb


                //UpdateMySql();

                // Initialize MSSQL
                var sqlContext = new TelerikKindergartenData();
                // SQL seeding
                //SeedSql.SeedSqlWithData(sqlContext, database); // Uncomment to seed sql

                // Load Excel Reports from ZIP File
                var excelManipulator = new ExcelManipulator();
                var importedExcelReports = excelManipulator.Import();

                var sqlManipulator = new SqlManipulator(sqlContext);
                sqlManipulator.AddExcelReports(importedExcelReports);

                using (var sqLiteContext = new DietsDataContext())
                {
                    sqlManipulator.AddExcelReports(importedExcelReports);
                    // Generate PDF Reports
                    var pdfReportsFromSql = sqlManipulator.GetPdfReportsData();
                    var pdfManipulator = new PdfManipulator();
                    pdfManipulator.GenerateReport(pdfReportsFromSql);

                    // Generate XML Report
                    var xmlReportsFromSql = sqlManipulator.GetXmlReportsData();
                    var xmlManipulator = new XmlManipulator();
                    xmlManipulator.GenerateReport(xmlReportsFromSql);

                    // JSON Reports
                    var jsonReportsFromSql = sqlManipulator.GetJsonReportsData();

                    var jsonManipulator = new JsonManipulator();
                    jsonManipulator.GenerateReports(jsonReportsFromSql);

                    var jsonReportsFromFiles = jsonManipulator.GetJsonReportsFromFiles();
                    var mySqlManipulator = new MySqlManipulator(mySqlContext);
                    mySqlManipulator.AddJsonReports(jsonReportsFromFiles);
                    // Load data from XML
                    var loadedXmlReports = xmlManipulator.LoadReportsFromFiles();

                    sqlManipulator.AddXmlReports(loadedXmlReports);
                    MongoAddManipulator.AddXmlReports(loadedXmlReports, database);
                    // Excel data

                    var reportsFromMySql = mySqlManipulator.GetReports();

                    var sqLiteManipulator = new SqLiteManipulator(sqLiteContext);
                    var foodReportsFromSqLite = sqLiteManipulator.GetFoodReports(sqLiteContext);
                    excelManipulator.ExportReports(reportsFromMySql, foodReportsFromSqLite);
                }

            }
        }

        private static void UpdateMySql()
        {
            using (var context = new TelerikKindergartenMySQLModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                MySqlUtilities.EnsureDB(schemaHandler);
                //// this is how you add the reports. This is an example, should be made separate.
                // context.Add(new JSONReportViewModel() { ProducerName = "ICO", ProductId = 2, ProductName = "Chair", TotalIncomes = 22, TotalQuantitySold = 300 });
                //// get the reports
                //context.SaveChanges();
                //Console.WriteLine(context.Reports.Where(r => true).First().ProducerName);
            }
        }
    }
}