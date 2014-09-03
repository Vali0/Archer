namespace TelerikKindergarten.ConsoleClient.SQL
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.Data;

    public class SeedSql
    {
        public static void SeedAssets(TelerikKindergartenData context, MongoDatabase mongoContext)
        {
            SaveAssets.SeedAssetsToSQL(context, mongoContext);
            SaveAssetsType.SeedAssetTypesToSQL(context, mongoContext);
            SaveChildrens.SeedChildrensToSQL(context, mongoContext);
            SaveDepartments.SeedDepartmentsToSQL(context, mongoContext);
            SaveEmployees.SeedEmployeesToSQL(context, mongoContext);
            SaveGroups.SeedGroupsToSQL(context, mongoContext);
            SaveProducers.SeedProducersToSQL(context, mongoContext);
            SaveProducts.SeedProductsToSQL(context, mongoContext);
        }
    }
}