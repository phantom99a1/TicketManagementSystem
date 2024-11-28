using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;

namespace Infrastructure.Service
{
    public class TicketService(IUnitOfWork unitOfWork) : ITicketService
    {
        public IUnitOfWork unitOfWork = unitOfWork;

        public GetTicketResponse? FindTicket(int ticketId)
        {
            var result = unitOfWork.Repository<Ticket>().GetByIdAsync(ticketId);
            if(result == null)
            {
                return null;
            }
            return new GetTicketResponse
            {
                TicketId = result.TicketId,
                Summary = result.Summary,
                Description = result.Description,
                ProductId = result.ProductId,
                PriorityId = result.PriorityId,
                CategoryId = result.CategoryId,
                Status = result.Status,
                RaisedBy = result.User?.Email,
                CreatedDate = result.RaisedDate,
                ExpectedDate = result.ExpectedDate,
            };
        }

        public List<GetTicketResponse> GetTickets(GetTicketRequest request)
        {
            var result = unitOfWork.TicketRepository.GetTickets(request);
            return result.Select(x => new GetTicketResponse
            {
                TicketId = x.TicketId,
                Summary = x.Summary,
                Description = x.Description,
                ProductId = x.ProductId,
                PriorityId = x.PriorityId,
                CategoryId = x.CategoryId,
                Status = x.Status,
                RaisedBy = x.User?.Email,
                CreatedDate = x.RaisedDate,
                ExpectedDate = x.ExpectedDate,
            }).ToList();
        }
    }
}
