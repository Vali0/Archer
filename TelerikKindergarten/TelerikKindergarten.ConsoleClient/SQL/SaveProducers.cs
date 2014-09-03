namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;
    using TelerikKindergarten.SQL.Model;
    using TelerikKindergarten.Data;
    using MongoDB.Driver;
    using MongoDatabaseOperations;

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