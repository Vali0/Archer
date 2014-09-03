namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using MongoDB.Bson.Serialization.Attributes;

    public partial class Asset
    {
        [BsonIgnore]
        public int AssetID { get; set; }

        [BsonIgnore]
        public int AssetTypeID { get; set; }

        [BsonIgnore]
        public int? DepartmentID { get; set; }

        [Column(TypeName = "money")]
        public decimal Value { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual AssetType AssetType { get; set; }

        [BsonIgnore]
        public virtual Department Department { get; set; }
    }
}
