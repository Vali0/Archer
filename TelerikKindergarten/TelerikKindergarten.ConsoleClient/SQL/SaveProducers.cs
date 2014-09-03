namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;

    using MongoDB.Driver;
    using MongoDatabaseOperations;

    using TelerikKindergarten.SQL.Model;
    using TelerikKindergarten.Data;

    class SaveProducers
    {

        public static void SeedProducersToSQL(TelerikKindergartenData context, MongoDatabase mongoContext)
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