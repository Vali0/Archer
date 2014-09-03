namespace TelerikKindergarten.ReportsManipulation
{    
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using MigraDoc.DocumentObjectModel;
    using MigraDoc.Rendering;
    using Newtonsoft.Json;

    using ReportModels;

    public class ExportReports
    {
        public static void CreatePdfReport(List<PdfReportViewModel> reports)
        {
            Document document = new Document();

            Section section = document.AddSection();
            var table = section.AddTable();
            table.Borders.Visible = true;
            var rowHeader = table.AddRow();

            for (int i = 0; i < 7; i++)
            {
                table.AddColumn("3cm");
                //rowHeader.Cells[i].Borders.Visible = true;
            }

            rowHeader.Cells[0].AddParagraph("Product name");
            rowHeader.Cells[1].AddParagraph("Producer");
            rowHeader.Cells[2].AddParagraph("Quantity");
            rowHeader.Cells[3].AddParagraph("Price");
            rowHeader.Cells[4].AddParagraph("Location");
            rowHeader.Cells[5].AddParagraph("Sum");
            rowHeader.Cells[6].AddParagraph("Date");

            foreach (var rep in reports)
            {
                var row = table.AddRow();
                row.Cells[0].AddParagraph(rep.ProductName);
                row.Cells[1].AddParagraph(rep.Producer);
                row.Cells[2].AddParagraph(rep.Quantity.ToString());
                row.Cells[3].AddParagraph(rep.Price.ToString());
                row.Cells[4].AddParagraph(rep.Location);
                row.Cells[5].AddParagraph(rep.Sum.ToString());
                row.Cells[6].AddParagraph(rep.Date.ToString());
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;
            renderer.RenderDocument();
            string filename = "kindergarden-demo.pdf";
            renderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        public static void CreateJsonReport(IEnumerable<JsonReportViewModel> dataToExport, string pathToSaveReport = "../../JsonReports")
        {

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter streamWriter = new StreamWriter(pathToSaveReport + "JsonReport.txt"))
            {
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    foreach (var data in dataToExport)
                    {
                        serializer.Serialize(writer, data);
                    }
                }
            }
        }

        public static void CreateExcelFile(IEnumerable<ExcelReportViewModel> dataToExport, string filePath)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + "\\ExcelReport.xlsx" + @"; Extended Properties=""Excel 12.0 Xml;HDR=YES;""";

            OleDbConnection xlsConnection = new OleDbConnection(connectionString);
            xlsConnection.Open();


            using (xlsConnection)
            {
                OleDbCommand cmd = new OleDbCommand("CREATE TABLE [Sheet1] ([Product] string, [Producer] string, [Invoice] string, [Department] string, [Quantity] int, [UnitPrice] decimal, [TotalPrice] decimal)", xlsConnection);
                cmd.ExecuteNonQuery();

                foreach (var data in dataToExport)
                {
                    OleDbCommand command = new OleDbCommand(
                        "INSERT INTO [Sheet1$] (Product, Producer, Invoice, Department, Quantity, UnitPrice, TotalPrice) " +
                                       "VALUES(@product, @producer, @invoice, @department, @quantity, @unitPrice, @totalPrice)", xlsConnection);

                    command.Parameters.AddWithValue("@product", data.Product);
                    command.Parameters.AddWithValue("@producer", data.Producer);
                    command.Parameters.AddWithValue("@invoice", data.InvoiceTitle);
                    command.Parameters.AddWithValue("@department", data.Department);
                    command.Parameters.AddWithValue("@quantity", data.Quantity);
                    command.Parameters.AddWithValue("@unitPrice", data.UnitPrice);
                    command.Parameters.AddWithValue("@totalPrice", data.TotalPrice);

                    command.ExecuteNonQuery();

                }
            }
        }

    }
}