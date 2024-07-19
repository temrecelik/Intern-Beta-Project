using Application.Repositories.CompanyRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.CompanyRepository;

public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
{
    public CompanyReadRepository(OrderManagementDbContext context) : base(context)
    {
    }
}