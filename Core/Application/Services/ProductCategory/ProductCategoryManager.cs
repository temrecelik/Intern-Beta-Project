using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.ProductCategoryRepository;
using Application.Repositories.ProductRepository;

namespace Application.Services.ProductCategory
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IProductCategoryReadRepository _productCategoryReadRepository;
        private readonly IProductCategoryWriteRepository _productCategoryWriteRepository;

        public ProductCategoryManager(IProductCategoryReadRepository productCategoryReadRepository, IProductCategoryWriteRepository productCategoryWriteRepository)
        {
            _productCategoryReadRepository = productCategoryReadRepository;
            _productCategoryWriteRepository = productCategoryWriteRepository;
        }


        public Task<Domain.Entities.ProductCategory> AddAsync(Domain.Entities.ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ProductCategory> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.ProductCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ProductCategory> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ProductCategory> UpdateAsync(Domain.Entities.ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
