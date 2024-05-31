using FashionStoreEcommerce.Core.Application.Abstractions.Orders;
using FashionStoreEcommerce.Core.Application.Abstractions.Orders.Services;
using FashionStoreEcommerce.Core.Application.Products;
using FashionStoreEcommerce.Core.Application.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FashionStoreEcommerce.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
