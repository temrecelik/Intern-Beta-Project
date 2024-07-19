using company = Domain.Entities.Company;

namespace Application.Services.Company
{
    public interface ICompanyService
    {
        IQueryable<company> GetAll();
        Task<company> GetByIdAsync(string id);
        Task<bool> AddAsync(Domain.Entities.Company entity);
        Task<bool> UpdateAsync(Domain.Entities.Company entity);
        Task<bool> DeleteAsync(string id);


    }
}
