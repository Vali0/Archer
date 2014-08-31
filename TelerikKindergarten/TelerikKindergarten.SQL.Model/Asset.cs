namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset
    {
        public int AssetID { get; set; }

        public int AssetTypeID { get; set; }

        public int? DepartmentID { get; set; }

        [Column(TypeName = "money")]
        public decimal Value { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual AssetType AssetType { get; set; }

        public virtual Department Department { get; set; }
    }
}
