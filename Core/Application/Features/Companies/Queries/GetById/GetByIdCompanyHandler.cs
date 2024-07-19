using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyHandler : IRequestHandler<GetByIdCompanyRequest, GetByIdCompanyResponse>
{

    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
	

	public GetByIdCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
	}

	public async Task<GetByIdCompanyResponse> Handle(GetByIdCompanyRequest request, CancellationToken cancellationToken)
    {
		var cacheKey = $"GetCompanyById_{request.Id}";
		var cachedCompany = _cacheService.GetAll<GetByIdCompanyResponse>(cacheKey);
		if (cachedCompany != null)
		{
			return cachedCompany;
		}


		Company company = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        GetByIdCompanyResponse response = _mapper.Map<GetByIdCompanyResponse>(company);

		_cacheService.Set(cacheKey, response, TimeSpan.FromHours(1)); // Cache süresi ayarlanabilir

		return response;
    }
}