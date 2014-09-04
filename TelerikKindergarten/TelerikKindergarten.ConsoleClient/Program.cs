﻿namespace TelerikKindergarten.ConsoleClient
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
            var database = server.GetDatabase("test");
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
                var importedExcelReports = ExcelManipulator.Import();
                SqlManipulator.AddExcelReports(importedExcelReports, sqlContext);

                using (var sqLiteContext = new DietsDataContext())
                {
                    //SqlManipulator.AddExcelReports(importedExcelReports, sqlContext);
                    // Generate PDF Reports
                    //var pdfReportsFromSql = SqlManipulator.GetPdfReportsData(sqlContext);
                    //PdfReporter.GenerateReport(pdfReportsFromSql);

                    // Generate XML Report
                    //var xmlReportsFromSql = SqlManipulator.GetXmlReportsData(sqlContext);
                    //XmlManipulator.GenerateReport(xmlReportsFromSql);

                    // JSON Reports
                    var jsonReportsFromSql = SqlManipulator.GetJsonReportsData(sqlContext);
                    JsonManipulator.GenerateReports(jsonReportsFromSql);

                    var jsonReportsFromFiles = JsonManipulator.GetJsonReportsFromFiles();

                    //MySqlManipulator.AddJsonReports(jsonReportsFromFiles, mySqlContext);
                    // Load data from XML
                    var loadedXmlReports = XmlManipulator.LoadReportsFromFiles();

                    SqlManipulator.AddXmlReports(loadedXmlReports, sqlContext);
                    SeedData.AddXmlReports(loadedXmlReports, database);
                    // Excel data
                    //ExcelManipulator.Export();

                    //var reportsFromMySql = MySqlManipulator.GetReports(mySqlContext);
                    var foodReportsFromSqLite = SqLiteManipulator.GetFoodReports(sqLiteContext);
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

        private static void SQLiteManipulations()
        {
            DietsDataContext diets = new DietsDataContext();
            var diet = diets.Diets.First();
            Console.WriteLine(diet.Menus.First().Dishes.First().Ingredients);
        }
    }
}