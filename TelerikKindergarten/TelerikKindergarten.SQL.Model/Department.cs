namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        public Department()
        {
            Assets = new HashSet<Asset>();
            Employees = new HashSet<Employee>();
        }

        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
