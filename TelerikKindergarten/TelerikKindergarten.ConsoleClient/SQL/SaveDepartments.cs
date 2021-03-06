﻿namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveDepartments
    {
        public static void SeedDepartmentsToSql(ITelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var departmentsForTransfer = MongoGetManipulator.GetDepartments(mongoContext);

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