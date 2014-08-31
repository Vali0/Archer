namespace TelerikKindergarten.ConsoleClient
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.SQL.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            var employee = new Employee() { FirstName = "Ivancho" };
            var context = new TelerikKindergartenSQLModel();
            context.Employees.Add(employee);   
        }

        private static void SeedMongoDb(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("TelerikKindergarten");

            var departments = database.GetCollection<Department>("departments");
            departments.RemoveAll();

            var groups = database.GetCollection<Group>("groups");
            groups.RemoveAll();

            var producers = database.GetCollection<Producer>("producers");
            producers.RemoveAll();
        }
    }
}
