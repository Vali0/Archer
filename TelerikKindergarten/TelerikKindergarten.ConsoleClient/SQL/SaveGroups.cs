namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveGroups
    {
        public static void SeedGroupsToSql(ITelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var groupsForTransfer = MongoGetManipulator.GetGroups(mongoContext);

            foreach (var group in groupsForTransfer)
            {
                context.Groups.Add(new Group()
                {
                    Name = group.Name,
                    Notes = group.Notes,
                    SupervisorID = 1
                });
            }

            context.SaveChanges();
        }
    }
}