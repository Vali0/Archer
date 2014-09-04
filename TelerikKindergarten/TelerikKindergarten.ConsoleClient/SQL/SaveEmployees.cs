namespace TelerikKindergarten.ConsoleClient.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;

    public class SaveEmployees
    {
        public static void SeedEmployeesToSql(TelerikKindergartenData context, MongoDatabase mongoContext)
        {
            var departmentsForTransfer = GetData.GetDepartmentsFromMongo(mongoContext);
            var employeesForTransfer = AddEmployees(departmentsForTransfer);

            foreach (var employee in employeesForTransfer)
            {
                context.Employees.Add(new Employee()
                {
                    FirstName = employee.MiddleName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.MiddleName
                });
            }

            context.SaveChanges();
        }

        private static ICollection<Employee> AddEmployees(IQueryable<Department> departments)
        {
            var employees = new List<Employee>();

            foreach (var department in departments)
            {
                foreach (var employee in department.Employees)
                {
                    employee.Department = department;
                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}