using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Infrastructure.Contexts;

namespace WildOasis.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    //pravljenje imitatora
    public Mock<IResortServices> MockResortService { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {

            services.RemoveAll<WildOasisDbContext>();
            
            var dbName = Guid.NewGuid().ToString();

            services.AddDbContext<WildOasisDbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });

            services.AddScoped(_ => MockResortService.Object);


        });

    }
}