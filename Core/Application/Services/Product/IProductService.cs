using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Product
{
    public interface IProductService
    {
        IQueryable<Domain.Entities.Product> GetAll();
        Task<Domain.Entities.Product> GetByIdAsync(string id);
        Task<Domain.Entities.Product> AddAsync(Domain.Entities.Product entity);
        Task<Domain.Entities.Product> UpdateAsync(Domain.Entities.Product entity);
        Task<Domain.Entities.Product> DeleteAsync(string id);
    }
}
