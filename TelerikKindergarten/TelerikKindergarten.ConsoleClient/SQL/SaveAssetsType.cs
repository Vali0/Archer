namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveAssetsType
    {
        public static void SeedAssetTypesToSql(ITelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var departments = GetData.GetDepartmentsFromMongo(mongoContext);
            var assets = SaveAssets.AddAssets(departments);
            var assetTypesForTransfer = AddAssetTypes(assets);

            foreach (var assetType in assetTypesForTransfer)
            {
                context.AssetTypes.Add(new AssetType()
                {
                    Name = assetType.Name
                });
            }

            context.SaveChanges();
        }

        private static ICollection<AssetType> AddAssetTypes(ICollection<Asset> assetsForTransfer)
        {
            var assetTypes = new List<AssetType>();

            foreach (var asset in assetsForTransfer)
            {
                var assetType = asset.AssetType;
                assetTypes.Add(assetType);
            }

            return assetTypes;
        }
    }
}