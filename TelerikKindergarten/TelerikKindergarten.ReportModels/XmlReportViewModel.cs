namespace TelerikKindergarten.ReportModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class XmlReportViewModel
    {
        [NotMapped]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Key]
        [BsonIgnore]
        public int XmlReportViewModelId { get; set; }

        public string Producer { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalSum { get; set; }
    }
}