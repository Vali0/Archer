namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;

    using MongoDB.Driver;
    using MongoDatabaseOperations;

    using TelerikKindergarten.SQL.Model;
    using TelerikKindergarten.Data;

    public class SaveProducers
    {

        public static void SeedProducersToSql(ITelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var producersForTransfer = GetData.GetProducersFromMongo(mongoContext);

            foreach (var producer in producersForTransfer)
            {
                context.Producers.Add(new Producer()
                {
                    Name = producer.Name
                });
            }

            context.SaveChanges();
        }
    }
}