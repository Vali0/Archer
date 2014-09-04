namespace TelerikKindergarten.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.SQLite.Data;

    public class SqLiteManipulator
    {
        private DietsDataContext sqLiteContext;

        public SqLiteManipulator(DietsDataContext sqLiteContext)
        {
            this.sqLiteContext = sqLiteContext;
        }
        public IEnumerable<FoodReportViewModel> GetFoodReports(DietsDataContext context)
        {
            // TODO: Add GetFoodReports functionality.
            throw new NotImplementedException();
        }
    }
}
