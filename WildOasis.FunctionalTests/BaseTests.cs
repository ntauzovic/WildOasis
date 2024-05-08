using Microsoft.Extensions.DependencyInjection;
using Moq;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Infrastructure.Contexts;

namespace WildOasis.FunctionalTests;

public class BaseTests :IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    public readonly HttpClient Client;
    public readonly WildOasisDbContext WildOasisDbContext;
    public readonly Mock<IResortServices> MockResortService;

    

    public BaseTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
        var scope = _factory.Services.CreateScope();
        WildOasisDbContext = scope.ServiceProvider.GetRequiredService<WildOasisDbContext>();
        MockResortService = factory.MockResortService;
    }

}