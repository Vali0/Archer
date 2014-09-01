namespace TelerikKindergarten.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TelerikKindergarten.Data.Migrations;
    using TelerikKindergarten.SQL.Model;

    public partial class TelerikKindergartenSQLModel : DbContext, ITelerikKindergartenContext
    {
        public TelerikKindergartenSQLModel()
            : base("name=TelerikKindergartenSQLModel")
        {
            Database.SetInitializer<TelerikKindergartenSQLModel>(new MigrateDatabaseToLatestVersion<TelerikKindergartenSQLModel, Configuration>());
        }

        public virtual IDbSet<Asset> Assets { get; set; }
        public virtual IDbSet<AssetType> AssetTypes { get; set; }
        public virtual IDbSet<Child> Children { get; set; }
        public virtual IDbSet<Department> Departments { get; set; }
        public virtual IDbSet<Employee> Employees { get; set; }
        public virtual IDbSet<Group> Groups { get; set; }

        public virtual IDbSet<Producer> Producers { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .Property(e => e.Value)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AssetType>()
                .HasMany(e => e.Assets)
                .WithRequired(e => e.AssetType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.SupervisorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Group>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Children)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);
        }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
