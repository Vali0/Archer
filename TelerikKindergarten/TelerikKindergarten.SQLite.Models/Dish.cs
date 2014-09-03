namespace TelerikKindergarten.SQLite.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Dish
    {
        [Key]
        public long DishID { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public int Price { get; set; }

        public long MenuID { get; set; }
    }
}
