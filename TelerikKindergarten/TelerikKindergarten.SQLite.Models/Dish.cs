namespace TelerikKindergarten.SQLite.Models
{
    using System.Collections.Generic;

    public class Dish
    {
        public int DishID { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public int Price { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
