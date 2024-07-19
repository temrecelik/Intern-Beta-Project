using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Order
{
    public interface IOrderService
    {
        IQueryable<Domain.Entities.Order> GetAll();
        Task<Domain.Entities.Order> GetByIdAsync(string id);
        Task<Domain.Entities.Order> AddAsync(Domain.Entities.Order entity);
        Task<Domain.Entities.Order> UpdateAsync(Domain.Entities.Order entity);
        Task<Domain.Entities.Order> DeleteAsync(string id);
    }
}
