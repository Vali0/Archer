namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveAssets
    {
        public static void SeedAssetsToSql(TelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var departmentsForTransfer = GetData.GetDepartmentsFromMongo(mongoContext);
            var assetsForTransfer = AddAssets(departmentsForTransfer);

            foreach (var asset in assetsForTransfer)
            {
                context.Assets.Add(new Asset()
                {
                    AssetTypeID = 1,
                    Value = asset.Value,
                    Description = asset.Description
                });
            }

            context.SaveChanges();
        }

        public static ICollection<Asset> AddAssets(IQueryable<Department> departamentsForTransfer)
        {
            var assets = new List<Asset>();

            foreach (var departament in departamentsForTransfer)
            {
                foreach (var asset in departament.Assets)
                {
                    asset.Department = departament;
                    assets.Add(asset);
                }
            }

            return assets;
        }
    }
}