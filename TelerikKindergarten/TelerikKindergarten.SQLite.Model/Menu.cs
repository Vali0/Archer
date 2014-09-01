namespace TelerikKindergarten.SQLite.Model
{
    using System.Collections.Generic;

    public class Menu
    {
        public int MenuID { get; set; }

        public virtual ICollection<Dish> Content { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<Diet> AppropriateDiets { get; set; }
    }
}
