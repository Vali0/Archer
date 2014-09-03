using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikKindergarten.SQLite.Models
{
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
