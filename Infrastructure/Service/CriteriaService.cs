using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;

namespace Infrastructure.Service
{
    public class CriteriaService(IUnitOfWork unitOfWork) : ICriteriaService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public List<Category> GetCategories()
        {
            return unitOfWork.Repository<Category>().ListAll();
        }

        public List<Priority> GetPriorities()
        {
            return unitOfWork.Repository<Priority>().ListAll();
        }

        public List<Product> GetProducts()
        {
            return unitOfWork.Repository<Product>().ListAll();
        }

        public List<string> GetStatus()
        {
            return ["NEW", "OPEN", "CLOSED"];
        }
    }
}
