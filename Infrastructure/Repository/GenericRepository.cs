using Domain.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T>(IdentityDbContext dbContext) : IGenericRepository<T> where T : class
    {
        internal readonly IdentityDbContext dbContext = dbContext;

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public T GetByIdAsync(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public List<T> ListAll()
        {
            return [.. dbContext.Set<T>()];
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = EntityState.Modified; 
        }
    }
}
