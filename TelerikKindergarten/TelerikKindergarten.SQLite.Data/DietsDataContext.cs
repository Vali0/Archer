namespace TelerikKindergarten.SQLite.Data
{
    using System.Data.Entity;

    using TelerikKindergarten.SQLite.Models;

    public class DietsDataContext : DbContext
    {
        //TODO : Why is this here?
        private const string CONNECTION_STRING = @"Data Source=..\..\..\..\Databases\Diets.db;Version=3;";

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Diet> Diets { get; set; }
    }
}
