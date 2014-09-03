namespace TelerikKindergarten.ReportModels
{
    using System;
    using System.Linq;

    public class PdfReportViewModel
    {
        public DateTime Date { get; set; }

        public string ProductName { get; set; }

        public string Producer { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public decimal Sum { get; set; }
    }
}