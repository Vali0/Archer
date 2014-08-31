namespace TelerikKindergarten.ReportsManipulation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImportReports
    {
        public static void ExtractZipReports()
        {
            string zipPath = @"Excel import reports.zip";
            string extractPath = @"extract";

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                    }
                    else
                    {
                        Directory.CreateDirectory(Path.Combine(extractPath, entry.FullName));
                    }
                }
            }
        }
    }
}