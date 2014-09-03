namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using MongoDB.Bson.Serialization.Attributes;

    public partial class AssetType
    {
        public AssetType()
        {
            Assets = new HashSet<Asset>();
        }

        [BsonIgnore]
        public int AssetTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [BsonIgnore]
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
