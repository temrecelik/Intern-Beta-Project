using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetAll;
using Application.Features.Companies.Queries.GetById;
using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetAll;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Repositories.ProductCategoryRepository;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseController<
        CreateProductCategoryRequest,
        UpdateProductCategoryRequest,
        DeleteProductCategoryRequest,
        GetByIdProductCategoryRequest,
        GetAllProductCategoryRequest,
        DeleteProductCategoryResponse,
        GetByIdProductCategoryResponse
    >
    {
        private readonly IProductCategoryUnitOfWork _unitOfWork;

        public ProductCategoryController(IMediator mediator, IProductCategoryUnitOfWork unitOfWork, ILogger<ProductCategoryController> logger) : base(logger, mediator)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("SeedData")]
        public async Task<IActionResult> SeedData(int numberOfRecords)
        {
            for (int i = 1; i <= numberOfRecords; i = i + 1)
            {
                var productCategory = new ProductCategory()
                {
                    Name = $"Product Category Name {i}",
                    Description = $"Product Category Description {i}"
                };

                await _unitOfWork.WriteRepository.AddAsync(productCategory);
            }

            await _unitOfWork.SaveAsync();

            return Ok($"{numberOfRecords} Product category have been created.");
        }
    }
}
