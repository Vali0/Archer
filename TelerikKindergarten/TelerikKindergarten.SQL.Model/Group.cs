namespace TelerikKindergarten.SQL.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
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

        [BsonIgnore]
        public int GroupID { get; set; }

        [NotMapped]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        [BsonIgnore]
        public int SupervisorID { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
