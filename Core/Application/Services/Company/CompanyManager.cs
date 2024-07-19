using Application.Repositories.CompanyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Company
{

    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly ICompanyWriteRepository _companyWriteRepository;

        public CompanyManager(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<bool> AddAsync(Domain.Entities.Company entity)
        {
             var values = await  _companyWriteRepository.AddAsync(entity);
             return true;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Company> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Domain.Entities.Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
