namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikKindergarten.SQL.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            var employee = new Employee() { FirstName = "Ivancho" };
            var context = new TelerikKindergartenSQLModel();
            context.Employees.Add(employee);   
        }
    }
}
