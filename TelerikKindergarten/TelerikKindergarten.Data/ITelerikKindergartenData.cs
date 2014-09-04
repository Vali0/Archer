namespace TelerikKindergarten.Data
{
    using System;

    using TelerikKindergarten.Data.Repositories;
    using TelerikKindergarten.ReportModels;
    using TelerikKindergarten.SQL.Model;

    public interface ITelerikKindergartenData
    {
        IGenericRepository<Asset> Assets { get; }

        IGenericRepository<AssetType> AssetTypes { get; }

        IGenericRepository<Child> Children { get; }

        IGenericRepository<Department> Departments { get; }

        IGenericRepository<Employee> Employees { get; }

        IGenericRepository<Group> Groups { get; }

        IGenericRepository<Producer> Producers { get; }

        IGenericRepository<Product> Products { get; }

        IGenericRepository<XmlReportViewModel> Reports { get; }

        void SaveChanges();
    }
}
