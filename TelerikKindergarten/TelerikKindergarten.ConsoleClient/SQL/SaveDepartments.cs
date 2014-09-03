namespace TelerikKindergarten.ConsoleClient.SQL
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveDepartments
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