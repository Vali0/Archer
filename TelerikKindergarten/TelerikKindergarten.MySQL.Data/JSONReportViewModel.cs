namespace TelerikKindergarten.ReportModels
{
    using System;
    using System.Linq;

    public class JsonReportViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProducerName { get; set; }

        public long TotalQuantitySold { get; set; }

        public decimal TotalIncomes { get; set; }
    }
}