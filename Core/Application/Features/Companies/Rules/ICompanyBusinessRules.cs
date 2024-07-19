using Domain.Entities;

namespace Application.Features.Companies.Rules;

public interface ICompanyBusinessRules
{
    void BrandIdShouldExistWhenSelected(Company company);
    Task BrandIdShouldExistWhenSelected(Guid id);
    Task CompanyNameCanNotBeDuplicatedWhenInserted(string name);
}