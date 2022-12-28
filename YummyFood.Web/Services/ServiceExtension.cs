

using YummyFood.Web.Interfaces;

namespace YummyFood.Web.Services
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Add All Services to the container.
            services.AddHttpClient<IProductService, ProductService>();
            services.AddHttpClient<IAuthService, AuthService>();
            services.AddHttpClient<IOrderService, OrderService>();

            // Add All Single Services 
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
