using IdentityServiceGateway.Service.Interface;

namespace IdentityServiceGateway.Service
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
