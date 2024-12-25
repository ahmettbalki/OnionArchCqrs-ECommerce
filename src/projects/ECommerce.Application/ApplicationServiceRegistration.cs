using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Login;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Serilog.Loggers;
using ECommerce.Application.Features.Categories.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace ECommerce.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceDependencies(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        services.AddScoped<CategoryBusinessRules>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        services.AddScoped<LoggerServiceBase, FileLogger>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(con => {
            con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            con.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            con.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            con.AddOpenBehavior(typeof(LoginBehavior<,>));
        }); 
        return services;
    }
}