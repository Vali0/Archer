namespace TelerikKindergarten.SQL.Model
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [BsonIgnore]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public int Quantity { get; set; }

        [BsonIgnore]
        public virtual Producer Producer { get; set; }
    }
}
