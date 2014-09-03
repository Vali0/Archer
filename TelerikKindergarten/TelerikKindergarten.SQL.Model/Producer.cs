namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public partial class Producer
    {
        public Producer()
        {            
            this.Products = new HashSet<Product>();
        }

        [BsonIgnore]
        public int ProducerId { get; set; }


        [NotMapped]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
