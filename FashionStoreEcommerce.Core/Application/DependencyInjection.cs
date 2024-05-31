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

            return services;
        }
    }
}
