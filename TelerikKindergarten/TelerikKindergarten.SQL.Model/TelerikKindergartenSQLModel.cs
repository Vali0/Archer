namespace TelerikKindergarten.SQL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TelerikKindergarten.SQL.Model.Migrations;

    public partial class TelerikKindergartenSQLModel : DbContext
    {
        public TelerikKindergartenSQLModel()
            : base("name=TelerikKindergartenSQLModel")
        {
            Database.SetInitializer<TelerikKindergartenSQLModel>(new MigrateDatabaseToLatestVersion<TelerikKindergartenSQLModel, Configuration>());
        }

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<AssetType> AssetTypes { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

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
    }
}
