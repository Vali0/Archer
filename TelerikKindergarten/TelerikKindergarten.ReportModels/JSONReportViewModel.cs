namespace TelerikKindergarten.ReportModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JSONReportViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Producer { get; set; }

        public long TotalQuantitySold { get; set; }

        public decimal TotalIncomes { get; set; }
    }
}