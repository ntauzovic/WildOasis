using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WildOasis.Application.Common.Behaviours;
using WildOasis.Application.Configuration;

namespace WildOasis.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddFluentValidationClientsideAdapters();
        services.AddFluentValidationAutoValidation();


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
        services.Configure<AesEncryptionConfiguration>(configuration.GetSection("AesEncryption"));//naziv koji se ovdje upise mora da se poklopi sa onim sto nam pise u appsetingsu

        return services;
    }
}