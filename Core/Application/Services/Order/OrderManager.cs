using Application.Repositories.OrderRepository;

namespace Application.Services.Order
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderManager(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public Task<Domain.Entities.Order> AddAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order> UpdateAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
