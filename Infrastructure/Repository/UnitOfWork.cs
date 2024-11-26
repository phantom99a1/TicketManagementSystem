using Domain.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections;

namespace Infrastructure.Repository
{
    public class UnitOfWork(IdentityDbContext context) : IUnitOfWork
    {
        private readonly IdentityDbContext context = context;
        private Hashtable repositories;

        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            repositories ??= [];
            var type = typeof(TEntity).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepository <TEntity>) repositories[type];
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesReturnBool()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
