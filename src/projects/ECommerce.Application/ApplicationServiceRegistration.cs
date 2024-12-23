using System.Reflection;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Serilog.Loggers;
using ECommerce.Application.Features.Categories.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace ECommerce.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceDependencies(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<LoggerServiceBase, FileLogger>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(con => {
            con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            con.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        }); 
        return services;
    }
}