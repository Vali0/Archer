namespace TelerikKindergarten.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using TelerikKindergarten.SQL.Model;    

    public interface ITelerikKindergartenContext
    {
        IDbSet<Asset> Assets { get; set; }

        IDbSet<AssetType> AssetTypes { get; set; }

        IDbSet<Child> Children { get; set; }

        IDbSet<Department> Departments { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Group> Groups { get; set; }
        
        IDbSet<Producer> Producers { get; set; }
        
        IDbSet<Product> Products { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
