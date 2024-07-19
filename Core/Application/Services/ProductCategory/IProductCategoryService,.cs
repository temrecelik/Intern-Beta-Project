using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductCategory
{
    public interface IProductCategoryService
    {
        IQueryable<Domain.Entities.ProductCategory> GetAll();
        Task<Domain.Entities.ProductCategory> GetByIdAsync(string id);
        Task<Domain.Entities.ProductCategory> AddAsync(Domain.Entities.ProductCategory entity);
        Task<Domain.Entities.ProductCategory> UpdateAsync(Domain.Entities.ProductCategory entity);
        Task<Domain.Entities.ProductCategory> DeleteAsync(string id);
    }
}
