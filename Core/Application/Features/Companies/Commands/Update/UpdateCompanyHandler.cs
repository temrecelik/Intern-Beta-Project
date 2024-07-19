using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
{

    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
	private readonly ICompanyBusinessRules _businessRules;
	private readonly ICacheService _cacheService;

	public UpdateCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICompanyBusinessRules businessRules, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
		_cacheService = cacheService;
	}

	public async Task<UpdateCompanyResponse> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
    {
		await _businessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);

		var company = _mapper.Map<Company>(request);

        await _unitOfWork.WriteRepository.Update(company);
		
		await _unitOfWork.SaveAsync();

		
		List<Company> companiesInCache = _cacheService.GetAll<List<Company>>("AllCompanies") ?? new List<Company>();

		companiesInCache.RemoveAll(c => c.Id == request.Id);

		companiesInCache.Add(company);

		_cacheService.Set("AllCompanies", companiesInCache, TimeSpan.FromHours(3));

		var  response = _mapper.Map<UpdateCompanyResponse>(company);
        return response;
    }
}