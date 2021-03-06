﻿namespace TelerikKindergarten.ConsoleClient.MongoDatabaseOperations
{
    using System.Linq;

    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    using TelerikKindergarten.SQL.Model;
    using TelerikKindergarten.ReportModels;

    public class MongoGetManipulator
    {
        public static IQueryable<Producer> GetProducers(MongoDatabase database)
        {
            var producers = database.GetCollection<Producer>("producers");

            var producersForTransfer = producers.AsQueryable<Producer>()
                                                .Where(p => p.Products.Any())
                                                .OrderBy(pr => pr.Name);

            return producersForTransfer;
        }

        public static IQueryable<Department> GetDepartments(MongoDatabase database)
        {
            var departments = database.GetCollection("departments");
            var departmentsForTransfer = departments.AsQueryable<Department>()
                                                    .Where(e => e.Employees.Any())
                                                    .Where(a => a.Assets.Any());

            return departmentsForTransfer;
        }

        public static IQueryable<Group> GetGroups(MongoDatabase database)
        {
            var groups = database.GetCollection<Group>("groups");
            var groupsForTransfer = groups.AsQueryable<Group>()
                                          .Where(c => c.Children.Any())
                                          .OrderBy(ch => ch.Name);

            return groupsForTransfer;
        }

        public static IQueryable<XmlReportViewModel> GetReports(MongoDatabase database)
        {

            var reports = database.GetCollection<XmlReportViewModel>("reports");

            return reports.AsQueryable<XmlReportViewModel>()
                .Where(r => true).OrderBy(x => x.Producer);
        }
    }
}