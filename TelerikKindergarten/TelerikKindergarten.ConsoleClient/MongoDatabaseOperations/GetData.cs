namespace TelerikKindergarten.ConsoleClient.MongoDatabaseOperations
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.SQL.Model;
    using MongoDB.Driver.Linq;

   public class GetData
    {
        public static IQueryable<Producer> GetProducersFromMongo(MongoDatabase database)
        {
            var producers = database.GetCollection<Producer>("producers");

            var producersForTransfer = producers.AsQueryable<Producer>()
                                                .Where(p => p.Products.Any())
                                                .OrderBy(pr => pr.Name);

            return producersForTransfer;
        }

        public static IQueryable<Department> GetDepartmentsFromMongo(MongoDatabase database)
        {
            var departments = database.GetCollection("departments");
            var departmentsForTransfer = departments.AsQueryable<Department>()
                                                    .Where(e => e.Employees.Any())
                                                    .Where(a => a.Assets.Any());

            return departmentsForTransfer;
        }

        public static IQueryable<Group> GetGroupsFromMongo(MongoDatabase database)
        {
            var groups = database.GetCollection<Group>("groups");
            var groupsForTransfer = groups.AsQueryable<Group>()
                                          .Where(c => c.Children.Any())
                                          .OrderBy(ch => ch.Name);

            return groupsForTransfer;
        }
    }
}