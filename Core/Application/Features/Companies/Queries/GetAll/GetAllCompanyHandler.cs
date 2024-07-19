using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Queries.GetAll;

public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyRequest, List<GetAllCompanyResponse>>
{

    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

	public GetAllCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
	}

	public Task<List<GetAllCompanyResponse>> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
    {
		var cacheKey = "GetAllCompanies";
		var cachedCompanies = _cacheService.GetAll<List<GetAllCompanyResponse>>(cacheKey);
		if (cachedCompanies != null)
		{
			return Task.FromResult(cachedCompanies);
		}


		List<Company> company = _unitOfWork.ReadRepository.GetAll().ToList();

        List<GetAllCompanyResponse> response = _mapper.Map<List<GetAllCompanyResponse>>(company);

		_cacheService.Set(cacheKey, response, TimeSpan.FromHours(1));

		return Task.FromResult(response);
    }
}