namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.Data;

    public class SeedSql
    {
        public static void SeedSqlWithData(ITelerikKindergartenData context, MongoDatabase mongoContext)
        {
            SaveAssetsType.SeedAssetTypesToSql(context, mongoContext);
            SaveAssets.SeedAssetsToSql(context, mongoContext);
            SaveDepartments.SeedDepartmentsToSql(context, mongoContext);
            SaveEmployees.SeedEmployeesToSql(context, mongoContext);
            SaveGroups.SeedGroupsToSql(context, mongoContext);
            SaveChildrens.SeedChildrensToSql(context, mongoContext);
            SaveProducers.SeedProducersToSql(context, mongoContext);
            SaveProducts.SeedProductsToSql(context, mongoContext);
        }
    }
}