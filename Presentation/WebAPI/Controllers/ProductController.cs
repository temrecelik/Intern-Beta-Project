using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;
using Application.Repositories.CompanyRepository;
using Application.Repositories.ProductCategoryRepository;
using Application.Repositories.ProductRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseController<
    CreateProductRequest,
    UpdateProductRequest,
    DeleteProductRequest,
    GetByIdProductRequest,
    GetAllProductRequest,
    DeleteProductResponse,
    GetByIdProductResponse
>
{
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly ICompanyUnitOfWork _companyUnitOfWork;
    private readonly IProductCategoryUnitOfWork _productCategoryUnitOfWork;

    public ProductController(
        IMediator mediator,
        IProductUnitOfWork unitOfWork,
        ICompanyUnitOfWork companyUnitOfWork,
        IProductCategoryUnitOfWork productCategoryUnitOfWork,
        IMapper mapper,
        ILogger<ProductController> logger) : base(logger, mediator)
    {
        _unitOfWork = unitOfWork;
        _companyUnitOfWork = companyUnitOfWork;
        _productCategoryUnitOfWork = productCategoryUnitOfWork;
       
    }

    [HttpPost("SeedData")]
    public async Task<IActionResult> SeedData(int numberOfRecords)
    {
        Random random = new Random();

        List<Guid> companyIdList = new List<Guid>();
        foreach (var company in _companyUnitOfWork.ReadRepository.GetAll())
        {
            companyIdList.Add(company.Id);
        }

        List<Guid> productCategoryIdList = new List<Guid>();
        foreach (var productCategory in _productCategoryUnitOfWork.ReadRepository.GetAll())
        {
            productCategoryIdList.Add(productCategory.Id);
        }

        for (int i = 1; i <= numberOfRecords; i = i + 1)
        {
            var request = new CreateProductRequest()
            {
                StockCount = i * 10,
                Price = i * 100,
                CompanyId = companyIdList[random.Next(0, companyIdList.Count)],
                ProductCategoryId = productCategoryIdList[random.Next(0, productCategoryIdList.Count)],
                Name = $"Product Name {i}",
                Description = $"Product Description {i}"
            };

            Product product = new()
            {
                StockCount = request.StockCount,
                Price = request.Price,
                Name = request.Name,
                Description = request.Description,
                Company = _companyUnitOfWork.ReadRepository.GetByIdAsync(request.CompanyId).Result,
                ProductCategory = _productCategoryUnitOfWork.ReadRepository.GetByIdAsync(request.ProductCategoryId)
                    .Result,
            };

            await _unitOfWork.WriteRepository.AddAsync(product);
        }

        await _unitOfWork.SaveAsync();

        return Ok($"{numberOfRecords} Product have been created.");
    }
}