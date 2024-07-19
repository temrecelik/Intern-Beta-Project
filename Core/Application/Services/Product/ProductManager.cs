using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.ProductRepository;

namespace Application.Services.Product
{
    public class ProductManager : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductManager(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public Task<Domain.Entities.Product> AddAsync(Domain.Entities.Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Product> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Product> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Product> UpdateAsync(Domain.Entities.Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
