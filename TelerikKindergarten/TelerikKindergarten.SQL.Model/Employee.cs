namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using MongoDB.Bson.Serialization.Attributes;

    public partial class Employee
    {
        public Employee()
        {
            Groups = new HashSet<Group>();
            Employees1 = new HashSet<Employee>();
        }

        [BsonIgnore]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [BsonIgnore]
        public int? ManagerID { get; set; }

        [BsonIgnore]
        public int? DepartmentID { get; set; }

        [BsonIgnore]
        public virtual Department Department { get; set; }

        [BsonIgnore]
        public virtual ICollection<Group> Groups { get; set; }

        [BsonIgnore]
        public virtual ICollection<Employee> Employees1 { get; set; }

        [BsonIgnore]
        public virtual Employee Employee1 { get; set; }
    }
}
