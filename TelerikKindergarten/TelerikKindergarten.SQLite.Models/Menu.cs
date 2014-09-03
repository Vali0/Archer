namespace TelerikKindergarten.SQLite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Menu
    {
        private ICollection<Dish> dishes;

        public Menu()
        {
            this.dishes = new HashSet<Dish>();
        }

        [Key]
        public long MenuID { get; set; }

        public string Description { get; set; }
        
        public long DietID { get; set; }

        public virtual ICollection<Dish> Dishes
        {
            get
            {
                return this.dishes;
            }

            set
            {
                this.dishes = value;
            }
        }
    }
}
