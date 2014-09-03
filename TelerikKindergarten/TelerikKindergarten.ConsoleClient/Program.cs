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
    using TelerikKindergarten.MySQL.Data;
    using TelerikKindergarten.ReportModels;
    using Telerik.OpenAccess;
    using TelerikKindergarten.SQLite.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            SQLiteManipulations();

            Console.WriteLine("SQLite finished");
            Console.ReadKey();
            Environment.Exit(0);
            //UpdateMySql();
            //UpdateMySql();

            //var employee = new Employee() { FirstName = "Ivancho" };
            var context = new TelerikKindergartenData();
            //context.Employees.Add(employee);

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



            var products = AddProducts(producersForTransfer);

            var groups = database.GetCollection<Group>("groups");
            var groupsForTransfer = groups.AsQueryable<Group>()
                                          .Where(c => c.Children.Any())
                                          .OrderBy(ch => ch.Name);

            var departments = database.GetCollection("departments");
            var departmentsForTransfer = departments.AsQueryable<Department>()
                                                    .Where(e => e.Employees.Any())
                                                    .Where(a => a.Assets.Any());

            var employeesForTransfer = AddEmployees(departmentsForTransfer);


            var assetsForTransfer = AddAssets(departmentsForTransfer);

            var assetTypesForTransfer = AddAssetTypes(assetsForTransfer);

            var childrenForTransfer = AddChildren(groupsForTransfer);

            //foreach (var child in childrenForTransfer)
            //{
            //    context.Children.Add(new Child()
            //    {
            //        FirstName = child.LastName,
            //        MiddleName = child.LastName,
            //        LastName = child.LastName,
            //        Address = child.Address,
            //        AdmissionDate = child.AdmissionDate,
            //        ConclusionDate = child.ConclusionDate,
            //        GroupID = 10
            //    });
            //}

            //foreach (var assetType in assetTypesForTransfer)
            //{
            //    context.AssetTypes.Add(new AssetType()
            //    {
            //        Name = assetType.Name
            //    });
            //}

            //foreach (var asset in assetsForTransfer)
            //{
            //    context.Assets.Add(new Asset()
            //    {
            //        AssetTypeID = 1,
            //        Value = asset.Value,
            //        Description = asset.Description
            //    });
            //}

            foreach (var department in departmentsForTransfer)
            {

                context.Departments.Add(new Department()
                {
                    Name = department.Name,
                    EmployeeId = department.EmployeeId,
                    //DepartmentHead = department.DepartmentHead
                });
            }

            foreach (var employee in employeesForTransfer)
            {
                context.Employees.Add(new Employee()
                {
                    FirstName = employee.MiddleName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.MiddleName
                });
            }

            foreach (var group in groupsForTransfer)
            {
                context.Groups.Add(new Group()
                {
                    Name = group.Name,
                    Notes = group.Notes,
                    //SupervisorID = 1
                });
            }


            foreach (var product in products)
            {
                context.Products.Add(new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ProductId = product.Producer.ProducerId // Check why null
                });
            }

            foreach (var producer in producersForTransfer)
            {
                context.Producers.Add(new Producer()
                {
                    Name = producer.Name
                });
            }

            //foreach (var department in departmentsForTransfer)
            //{

            //    context.Departments.Add(new Department()
            //    {
            //        Name = department.Name,
            //        EmployeeId = department.EmployeeId,
            //        //DepartmentHead = department.DepartmentHead
            //    });
            //}

            //foreach (var employee in employeesForTransfer)
            //{
            //    context.Employees.Add(new Employee()
            //    {
            //        FirstName = employee.MiddleName,
            //        MiddleName = employee.MiddleName,
            //        LastName = employee.MiddleName
            //    });
            //}

            //foreach (var group in groupsForTransfer)
            //{
            //    context.Groups.Add(new Group()
            //    {
            //        Name = group.Name,
            //        Notes = group.Notes,
            //        SupervisorID = 1
            //    });
            //}

            //foreach (var product in products)
            //{
            //    context.Products.Add(new Product()
            //    {
            //        Name = product.Name,
            //        Price = product.Price,
            //        Quantity = product.Quantity,
            //        ProductId = product.Producer.ProducerId
            //    });
            //}

            //foreach (var producer in producersForTransfer)
            //{
            //    context.Producers.Add(new Producer()
            //    {
            //        Name = producer.Name
            //    });
            //}

            context.SaveChanges();
        }

        private static ICollection<Child> AddChildren(IOrderedQueryable<Group> groupsForTransfer)
        {
            var childs = new List<Child>();

            foreach (var group in groupsForTransfer)
            {
                foreach (var child in group.Children)
                {
                    child.Group = group;
                    childs.Add(child);
                }
            }

            return childs;
        }

        private static ICollection<AssetType> AddAssetTypes(ICollection<Asset> assetsForTransfer)
        {
            var assetTypes = new List<AssetType>();

            foreach (var asset in assetsForTransfer)
            {
                var assetType = asset.AssetType;
                assetTypes.Add(assetType);
            }

            return assetTypes;
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

        private static ICollection<Product> AddProducts(IQueryable<Producer> producers)
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

        private static ICollection<Employee> AddEmployees(IQueryable<Department> departments)
        {
            var employees = new List<Employee>();

            foreach (var department in departments)
            {
                foreach (var employee in department.Employees)
                {
                    employee.Department = department;
                    employees.Add(employee);
                }
            }

            return employees;
        }

        private static ICollection<Asset> AddAssets(IQueryable<Department> departamentsForTransfer)
        {
            var assets = new List<Asset>();

            foreach (var departament in departamentsForTransfer)
            {
                foreach (var asset in departament.Assets)
                {
                    asset.Department = departament;
                    assets.Add(asset);
                }
            }

            return assets;
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