using Application.Features.Companies.Rules;
using Application.Features.Orders.Rules;
using Application.Features.ProductCategories.Rules;
using Application.Features.Products.Rules;
using Application.Features.Users.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));
        services.AddAutoMapper(typeof(ServiceRegistration));


        services.AddScoped<ICompanyBusinessRules, CompanyBusinessRules>();

        services.AddScoped<OrderBusinessRules>();
		services.AddScoped<ProductCategoryBusinessRules>();
		services.AddScoped<ProductBusinessRules>();
        services.AddScoped<UserBusinessRules>();
	}
}