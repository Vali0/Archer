namespace TelerikKindergarten.ReportsManipulation
{
    using MigraDoc.DocumentObjectModel;
    using MigraDoc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportReports
    {
        public static void CreatePdfReport()
        {
            Document document = new Document();

            Section section = document.AddSection();
            var table = section.AddTable();
            var column = table.AddColumn("5cm");
            column = table.AddColumn("2cm");

            var row = table.AddRow();
            row.Cells[0].AddParagraph("Name");
            row.Cells[1].AddParagraph("Age");
            row.Cells[0].Borders.Visible = true;
            row.Cells[1].Borders.Visible = true;

            var firstRow = table.AddRow();
            firstRow.Cells[0].AddParagraph("Pesho");
            firstRow.Cells[1].AddParagraph("12");
            firstRow.Cells[0].Borders.Visible = true;
            firstRow.Cells[1].Borders.Visible = true;

            var secondRow = table.AddRow();
            secondRow.Cells[0].AddParagraph("Gosho");
            secondRow.Cells[1].AddParagraph("50");
            secondRow.Cells[0].Borders.Visible = true;
            secondRow.Cells[1].Borders.Visible = true;


            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;
            renderer.RenderDocument();
            string filename = "kindergarden-demo.pdf";
            renderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }
    }
}