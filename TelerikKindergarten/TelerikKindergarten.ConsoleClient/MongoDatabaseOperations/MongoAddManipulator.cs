namespace TelerikKindergarten.ConsoleClient.MongoDatabaseOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.SQL.Model;

    public class MongoAddManipulator
    {
        private string[] ASSET_TYPES_NAMES = {
                                           "Toy(medium)",
                                           "Toy(big)",
                                           "Toy(small)",
                                           "Lamp",
                                           "Bucket",
                                           "Lightbulb",
                                           "Oven",
                                           "Plate(small)",
                                           "Plate(big)",
                                           "Chair",
                                           "Table",
                                           "Broom",
                                           "Cleaning solution",
                                           "Pan",
                                           "Utensils",
                                           "Bowl",
                                           "Carpet(big)"
                                       };

        private MongoDatabase database;

        public MongoAddManipulator(MongoDatabase database)
        {
            this.database = database;
        }

        public void AddXmlReports(IEnumerable<XmlReportViewModel> xmlReports)
        {
            var reports = this.database.GetCollection<XmlReportViewModel>("reports");

            reports.InsertBatch<XmlReportViewModel>(xmlReports);
        }

        public void SeedDatabase()
        {
            var producers = this.database.GetCollection<Producer>("producers");
            producers.RemoveAll();
            SeedProducers(producers);

            var departments = this.database.GetCollection<Department>("departments");
            departments.RemoveAll();
            SeedDepartments(departments);

            var groups = this.database.GetCollection<Group>("groups");
            groups.RemoveAll();
            SeedGroups(groups);
        }

        private void SeedGroups(MongoCollection<Group> groups)
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

        private void SeedDepartments(MongoCollection<Department> departments)
        {
            string[] deptNames = new string []{
                                    "Cooking",
                                    "Cleaning",
                                    "Children care",
                                    "Maintenance"
                                 };

            for (int currentDept = 0; currentDept < deptNames.Length; currentDept++)
            {
                var currentDepartment = new Department() { Name = deptNames[currentDept] };
                currentDepartment.DepartmentHead = new Employee() { FirstName = "Department head of " + currentDepartment.Name };

                for (int i = 0; i < 10; i++)
                {
                    var employee = new Employee() { MiddleName = currentDepartment.Name + " Jonny " + i };
                    currentDepartment.Employees.Add(employee);
                }

                for (int i = 0; i < ASSET_TYPES_NAMES.Length; i++)
                {
                    var asset = new Asset() { Description = "Descr" + i, Value = i * 5, AssetType = new AssetType() { Name = ASSET_TYPES_NAMES[i] } };
                    currentDepartment.Assets.Add(asset);
                }

                departments.Insert(currentDepartment);
            }
        }

        private void SeedProducers(MongoCollection<Producer> producers)
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
    }
}
