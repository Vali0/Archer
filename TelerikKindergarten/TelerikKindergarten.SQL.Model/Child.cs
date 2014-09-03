namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using MongoDB.Bson.Serialization.Attributes;

    public partial class Child
    {
        [BsonIgnore]
        public int ChildID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime AdmissionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ConclusionDate { get; set; }

        [BsonIgnore]
        public int GroupID { get; set; }

        [BsonIgnore]
        public virtual Group Group { get; set; }
    }
}
