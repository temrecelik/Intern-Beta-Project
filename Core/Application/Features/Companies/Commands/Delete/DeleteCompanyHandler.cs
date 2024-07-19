using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyRequest, DeleteCompanyResponse>
{
    
    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

	public DeleteCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
	}

	public async Task<DeleteCompanyResponse> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
    {
        Company company = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        await _unitOfWork.WriteRepository.RemoveAsync(request.Id);

		await _unitOfWork.SaveAsync();

		List<Company> companiesInCache = _cacheService.GetAll<List<Company>>("AllCompanies") ?? new List<Company>();

		// Silinen şirketi cache'den burada çıkarıyoruz
		companiesInCache.RemoveAll(c => c.Id == request.Id);

		// Güncellenmiş listeyi tekrar önbelleğe koyma işlemi
		_cacheService.Set("AllCompanies", companiesInCache, TimeSpan.FromHours(3));




		DeleteCompanyResponse response = _mapper.Map<DeleteCompanyResponse>(company);

        return response;
    }
}