using Domain.DTO.Request;
using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository
{
    public class TicketRepository(IdentityDbContext dbContext) : GenericRepository<Ticket>(dbContext), ITicketRepository
    {
        public List<Ticket> GetTickets(GetTicketRequest request)
        {
            IQueryable<Ticket> query = dbContext.Set<Ticket>()
                .Include(x => x.Category)
                .Include(x => x.Product)
                .Include(x => x.Priority)
                .Include(x => x.User)
                .Include(x => x.AssignedTo);

            if(request == null)
            {
                return [.. query];
            }

            if (!string.IsNullOrEmpty(request.Summary))
            {
                query = query.Where(x => (EF.Functions.Like(x.Summary, $"%{request.Summary}%")));
            }

            if(request.ProductId != null && request.ProductId.Length > 0)
            {
                query = query.Where(x => request.ProductId.Contains(x.ProductId));
            }

            if (request.CategoryId != null && request.CategoryId.Length > 0)
            {
                query = query.Where(x => request.CategoryId.Contains(x.CategoryId));
            }

            if (request.PriorityId != null && request.PriorityId.Length > 0)
            {
                query = query.Where(x => request.PriorityId.Contains(x.PriorityId));
            }

            if (request.Status != null && request.Status.Length > 0)
            {
                query = query.Where(x => request.Status.Contains(x.Status));
            }

            if (request.RaisedBy != null && request.RaisedBy.Length > 0)
            {
                query = query.Where(x => request.RaisedBy.Contains(x.RaisedBy));
            }

            return [.. query];
        }
    }
}
