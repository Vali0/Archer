namespace TelerikKindergarten.ReportModels
{
    using System;
    using System.Linq;

    public class XmlReportViewModel
    {
        public string Producer { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalSum { get; set; }
    }
}