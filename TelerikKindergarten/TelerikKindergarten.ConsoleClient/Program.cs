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

    public class Program
    {
        public static void Main(string[] args)
        {
            var sqlContext = new TelerikKindergartenData();
            
            // Load Excel Reports from ZIP File
            var importedExcelReports = ExcelManipulator.Import();
            // import to sql :

            SqlManipulator.AddExcelReports(importedExcelReports, sqlContext);
            // Generate PDF Reports
            var pdfReportsFromSql = SqlManipulator.GetPdfReportsData(sqlContext);

            PdfReporter.GenerateReport(pdfReportsFromSql);

            // Generate XML Report
            var xmlReportsFromSql = SqlManipulator.GetXmlReportsData(sqlContext);
            XmlManipulator.GenerateReport(xmlReportsFromSql);

            // JSON Reports
            JsonManipulator.GenerateReport();

            // Load data from XML
            XmlManipulator.LoadData();

            // Excel data
            ExcelManipulator.Export();

            //Mongodb seeding
            string mongoConnectionString = "mongodb://localhost";
            //Get data from the base.
            var client = new MongoClient(mongoConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            //SeedMongoDb(mongoConnectionString);

            // SQL seeding
            var context = new TelerikKindergartenData();
            //UpdateMySql();
        }

        private static void SeedMongoDb(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");

            var producers = database.GetCollection<Producer>("producers");
            producers.RemoveAll();
            SeedProducers(producers);

            var departments = database.GetCollection<Department>("departments");
            departments.RemoveAll();
            SeedDepartments(departments);

            var groups = database.GetCollection<Group>("groups");
            groups.RemoveAll();
            SeedGroups(groups);
        }

        private static void SeedGroups(MongoCollection<Group> groups)
        {
            for (int indexOfGroups = 0; indexOfGroups < 20; indexOfGroups++)
            {
                var currentGroup = new Group() { Name = "G " + indexOfGroups, Notes = "Notes" };

                for (int i = 0; i < 10; i++)
                {
                    var currentStudent = new Child() { ConclusionDate = DateTime.Now, LastName = "Child" + i + " " + indexOfGroups, Address = "Sofia?" };
                    currentGroup.Children.Add(currentStudent);
                }

                var teacher = new Employee() { LastName = "Name" + indexOfGroups };
                currentGroup.Employee = teacher;
                groups.Insert(currentGroup);
            }
        }

        private static void SeedDepartments(MongoCollection<Department> departments)
        {
            for (int indexOfDepartments = 0; indexOfDepartments < 5; indexOfDepartments++)
            {
                var currentDepartment = new Department() { Name = "Dept." + indexOfDepartments };
                currentDepartment.DepartmentHead = new Employee() { FirstName = "Department head of " + currentDepartment.Name };

                for (int i = 0; i < 10; i++)
                {
                    var employee = new Employee() { MiddleName = currentDepartment.Name + " Jonny " + i };
                    currentDepartment.Employees.Add(employee);
                }

                for (int i = 0; i < 10; i++)
                {
                    var asset = new Asset() { Description = "Descr" + i, Value = i * 5, AssetType = new AssetType() { Name = "Chair" } };
                    currentDepartment.Assets.Add(asset);
                }

                departments.Insert(currentDepartment);
            }
        }

        private static void SeedProducers(MongoCollection<Producer> producers)
        {
            for (int indexOfProducers = 0; indexOfProducers < 20; indexOfProducers++)
            {
                var currentProducer = new Producer() { Name = "Producer" + indexOfProducers };

                for (int i = 0; i < 30; i++)
                {
                    var currentProduct = new Product() { Name = "Product " + currentProducer.Name + " " + i, Price = i, Quantity = i * 10 };

                    currentProducer.Products.Add(currentProduct);
                }

                producers.Insert(currentProducer);
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