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
            var diets = context.Diets.Where(x => true);
            var reports = new List<FoodReportViewModel>();

            foreach (var item in diets)
            {
                var foodReport = new FoodReportViewModel()
                {
                    DietName = item.Description,
                    MenuName = item.Menus.First().Description
                };

                reports.Add(foodReport);
            }

            return reports;
        }
    }
}
