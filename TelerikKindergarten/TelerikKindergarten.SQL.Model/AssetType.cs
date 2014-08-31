namespace TelerikKindergarten.SQL.Model
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
