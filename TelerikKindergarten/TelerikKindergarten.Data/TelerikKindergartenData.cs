namespace TelerikKindergarten.Data
{
    using System;
    using System.Collections.Generic;

    using TelerikKindergarten.Data.Repositories;
    using TelerikKindergarten.SQL.Model;

    public class TelerikKindergartenData : ITelerikKindergartenData
    {
        private ITelerikKindergartenContext context;
        private IDictionary<Type, object> repositories;

        public TelerikKindergartenData() : this(new TelerikKindergartenSQLModel())
        {
        }

        public TelerikKindergartenData(ITelerikKindergartenContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public IGenericRepository<Asset> Assets
        {
            get
            {
                return this.GetRepository<Asset>();
            }
        }

        public IGenericRepository<AssetType> AssetTypes
        {
            get
            {
                return this.GetRepository<AssetType>();
            }
        }

        public IGenericRepository<Child> Children
        {
            get
            {
                return this.GetRepository<Child>();
            }
        }

        public IGenericRepository<Department> Departments
        {
            get
            {
                return this.GetRepository<Department>();
            }
        }

        public IGenericRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>();
            }
        }

        public IGenericRepository<Group> Groups
        {
            get
            {
                return this.GetRepository<Group>();
            }
            
        }

        public IGenericRepository<Producer> Producers
        {
            get
            {
                return this.GetRepository<Producer>();
            }
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}