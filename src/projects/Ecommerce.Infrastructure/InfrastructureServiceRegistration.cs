using ECommerce.Application.Services.Infrastructure;
using Ecommerce.Infrastructure.CloudinaryServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Ecommerce.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<ICloudinaryService, CloudinaryService>();
        service.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        return service;
    }
}
