namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using TelerikKindergarten.SQL.Model;
    using TelerikKindergarten.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var employee = new Employee() { FirstName = "Ivancho" };
            var context = new TelerikKindergartenData();
            context.Employees.Add(employee);   

            //Mongodb seeding
            string mongoConnectionString = "mongodb://localhost";

            SeedMongoDb(mongoConnectionString);

            //Get data from the base.
            var client = new MongoClient(mongoConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");

            var producers = database.GetCollection<Producer>("producers");

            //You can just use AsQueryable to get all of them, or use Linq after. Not all Linq commands are supported!
            var producersForTransfer = producers.AsQueryable<Producer>()
                                                .Where(p => p.Products.Any())
                                                .OrderBy(pr => pr.Name);

            foreach (var producer in producersForTransfer)
            {
                Console.WriteLine(producer.Name);
            }
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

        private static ICollection<Product> Add(ICollection<Producer> producers)
        {
            var products = new List<Product>();

            foreach (var producer in producers)
            {
                foreach (var product in producer.Products)
                {
                    product.Producer = producer;
                    products.Add(product);
                }
            }

            return products;
        }
    }
}