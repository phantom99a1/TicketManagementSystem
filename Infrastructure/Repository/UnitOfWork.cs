using Domain.Repository;
using Infrastructure.Data;
using System.Collections;

namespace Infrastructure.Repository
{
    public class UnitOfWork(AppDBContext context, ITicketRepository ticketRepository) : IUnitOfWork
    {
        private readonly AppDBContext context = context;
        private Hashtable repositories;
        public ITicketRepository TicketRepository { get; } = ticketRepository;

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
