using Domain.DTO.Request;
using Domain.Entities;

namespace Domain.Repository
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        List<Ticket> GetTickets(GetTicketRequest request);
    }
}
