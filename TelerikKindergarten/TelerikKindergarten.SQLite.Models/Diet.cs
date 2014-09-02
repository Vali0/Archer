using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikKindergarten.SQLite.Models
{
    public class Diet
    {
        public int DietID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
