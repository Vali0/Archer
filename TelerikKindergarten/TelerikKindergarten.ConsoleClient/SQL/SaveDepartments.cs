namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    class SaveDepartments
    {
        public static void SeedDepartmentsToSQL(TelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var departmentsForTransfer = GetData.GetDepartmentsFromMongo(mongoContext);

            foreach (var department in departmentsForTransfer)
            {
                context.Departments.Add(new Department()
                {
                    Name = department.Name,
                    EmployeeId = department.EmployeeId,
                    //DepartmentHead = department.DepartmentHead
                });
            }

            context.SaveChanges();
        }
    }
}