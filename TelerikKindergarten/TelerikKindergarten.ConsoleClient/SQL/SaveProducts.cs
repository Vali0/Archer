namespace TelerikKindergarten.ConsoleClient.SQL
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    class SaveProducts
    {
        public static void SeedProductsToSQL(TelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var producersForTransfer = GetData.GetProducersFromMongo(mongoContext);

            var products = AddProducts(producersForTransfer);
            
            foreach (var product in products)
            {
                context.Products.Add(new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ProductId = product.Producer.ProducerId
                });
            }

            context.SaveChanges();
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
    }
}