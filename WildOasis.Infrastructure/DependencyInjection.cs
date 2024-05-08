using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Infrastructure.Configuration;
using WildOasis.Infrastructure.Contexts;
using WildOasis.Infrastructure.Services;

namespace WildOasis.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            services.AddDbContext<WildOasisDbContext>(options =>
                options.UseNpgsql(dbConfiguration.ConnectionString,
                    x => x.MigrationsAssembly(typeof(WildOasisDbContext).Assembly.FullName)));
        }

        services.AddScoped<IWildOasisDbContext>(provider => provider.GetRequiredService<WildOasisDbContext>());

        services.AddScoped<IResortServices, ResortService>();
        services.AddScoped<ICabinService, CabinServices>();
        
        return services;
    }

}