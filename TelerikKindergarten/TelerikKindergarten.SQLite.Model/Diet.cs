namespace TelerikKindergarten.SQLite.Model
{
    using System.Collections.Generic;

    public class Diet
    {
        public int DietID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
