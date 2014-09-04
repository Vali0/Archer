namespace TelerikKindergarten.SQLite.Data
{
    using System.Data.Entity;

    using TelerikKindergarten.SQLite.Models;

    public class DietsDataContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Diet> Diets { get; set; }
    }
}
