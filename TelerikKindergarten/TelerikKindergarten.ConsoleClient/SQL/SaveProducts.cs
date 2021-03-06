﻿namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveProducts
    {
        public static void SeedProductsToSql(ITelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var producersForTransfer = MongoGetManipulator.GetProducers(mongoContext);

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