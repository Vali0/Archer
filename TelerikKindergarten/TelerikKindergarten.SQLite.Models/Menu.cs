namespace TelerikKindergarten.SQLite.Models
{
    using System.Collections.Generic;

    public class Menu
    {
        public int MenuID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

        public virtual ICollection<Diet> Diets { get; set; }
    }
}
