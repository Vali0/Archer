namespace TelerikKindergarten.ConsoleClient.SQL
{
    using MongoDB.Driver;
    using System;
    using System.Linq;
    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveGroups
    {
        public static void SeedGroupsToSQL(TelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var groupsForTransfer = GetData.GetGroupsFromMongo(mongoContext);

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