namespace TelerikKindergarten.SQLite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Diet
    {
        private ICollection<Menu> menus;

        public Diet()
        {
            this.menus = new HashSet<Menu>();
        }

        [Key]
        public long DietID { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<Menu> Menus
        {
            get
            {
                return this.menus;
            }
            set
            {
                this.menus = value;
            }
        }
    }
}
