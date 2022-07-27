using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Dealership_App.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected CarDbContext ctx;
        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(int ID)
        {
            ctx.Set<T>().Remove(Read(ID));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);
        

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T entity);

        public Repository(CarDbContext context)
        {
            ctx = context;
        }
    }
}
