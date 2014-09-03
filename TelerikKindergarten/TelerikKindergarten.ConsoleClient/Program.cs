namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.SQL.Model;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.MySQL.Data;
    using TelerikKindergarten.ReportModels;
    using Telerik.OpenAccess;
    using TelerikKindergarten.SQLite.Data;
    using MongoDB.Driver;
    using TelerikKindergarten.ConsoleClient.SQL;
    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;

    public class Program
    {
        public static void Main(string[] args)
        {
            //Mongodb seeding
            string mongoConnectionString = "mongodb://localhost";
            //Get data from the base.
            var client = new MongoClient(mongoConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            //SeedData.SeedMongoDb(mongoConnectionString); // Uncomment to seed mongodb
            
            // Load Excel Reports from ZIP File
            //var importedExcelReports = ExcelManipulator.Import();
            // import to sql :

            //SqlManipulator.AddExcelReports(importedExcelReports, sqlContext);
            // Generate PDF Reports
            //var pdfReportsFromSql = SqlManipulator.GetPdfReportsData(sqlContext);
            //PdfReporter.GenerateReport(pdfReportsFromSql);

            // Generate XML Report
            //var xmlReportsFromSql = SqlManipulator.GetXmlReportsData(sqlContext);
            //XmlManipulator.GenerateReport(xmlReportsFromSql);

            // JSON Reports
            //JsonManipulator.GenerateReport();

            // Load data from XML
            //XmlManipulator.LoadData();

            // Excel data
            //ExcelManipulator.Export();

            

            // SQL seeding
            var sqlContext = new TelerikKindergartenData();
            //SeedSql.SeedSqlWithData(sqlContext, database); // Uncomment to seed sql

            //UpdateMySql();
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

        private static void SQLiteManipulations()
        {
            DietsDataContext diets = new DietsDataContext();
            var diet = diets.Diets.First();
            Console.WriteLine(diet.Menus.First().Dishes.First().Ingredients);
        }
    }
}