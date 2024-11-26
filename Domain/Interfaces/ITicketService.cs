using Domain.DTO.Request;
using Domain.DTO.Response;

namespace Domain.Interfaces
{
    public interface ITicketService
    {
        List<GetTicketResponse> GetTickets(GetTicketRequest request);
        GetTicketResponse FindTicket(int ticketId);
    }
}
