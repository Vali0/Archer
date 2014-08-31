namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        public Group()
        {
            Children = new HashSet<Child>();
        }

        public int GroupID { get; set; }

        public int SupervisorID { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
