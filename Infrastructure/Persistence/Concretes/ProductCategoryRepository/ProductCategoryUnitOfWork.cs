using Application.Repositories.CompanyRepository;
using Application.Repositories.ProductCategoryRepository;
using Persistence.Concretes.OderRepository;
using Persistence.Contexts;

namespace Persistence.Concretes.ProductCategoryRepository;

public class ProductCategoryUnitOfWork : UnitOfWork<IProductCategoryReadRepository, IProductCategoryWriteRepository ,ProductCategoryReadRepository, ProductCategoryWriteRepository>, IProductCategoryUnitOfWork
{
    public ProductCategoryUnitOfWork(OrderManagementDbContext context) : base(context,
        ctx => new ProductCategoryReadRepository(ctx), ctx => new ProductCategoryWriteRepository(ctx))

    {
    }
}