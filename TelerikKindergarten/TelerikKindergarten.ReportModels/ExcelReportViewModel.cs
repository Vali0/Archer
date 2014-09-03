namespace TelerikKindergarten.ReportModels
{
    public class ExcelReportViewModel
    {
        public string Product { get; set; }

        public string Producer { get; set; }

        public string InvoiceTitle { get; set; }

        public string Department { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
