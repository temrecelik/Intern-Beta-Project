using Application.Aspects.Autofac.Validation;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
    private readonly ICompanyBusinessRules _businessRules;
    private readonly ICacheService _cacheService;

	public CreateCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICompanyBusinessRules businessRules, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
		_cacheService = cacheService;
	}

	[ValidationAspect(typeof(CreateCompanyRequestValidator))]
	public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);

        Company company = _mapper.Map<Company>(request);

        await _unitOfWork.WriteRepository.AddAsync(company);

        await _unitOfWork.SaveAsync();
		//await _mailService.SendMessageAsync("busekose01@icloud.com",
		//    "örnek mail", "<strong>bu bir örnek maildir.</strong>");


		List<Company> companiesInCache = _cacheService.GetAll<List<Company>>("AllCompanies") ?? new List<Company>();
		companiesInCache.Add(company);

		_cacheService.Set("AllCompanies", companiesInCache, TimeSpan.FromHours(3));

		_cacheService.Remove("All Of Them");

		CreateCompanyResponse response = _mapper.Map<CreateCompanyResponse>(company);

        return response;
    }
}