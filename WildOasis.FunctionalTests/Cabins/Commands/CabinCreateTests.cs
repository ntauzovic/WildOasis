using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.BaseTest.Builders.Cabin.Commands;
using WildOasis.BaseTest.Builders.Domain;
using WildOasis.BaseTest.Builders.Dto;

namespace WildOasis.FunctionalTests.Cabins.Commands;

public class CabinCreateTests : BaseTests
{
    [Fact]
    public async Task CabinCreateTest_GivenAllCorectParametars_ReturnValidCabinDetails()
    {
        var resort = new ResortBuilder().Build();
        await WildOasisDbContext.Resorts.AddAsync(resort);
        await WildOasisDbContext.SaveChangesAsync();

        var cabinDto = new CabinCreateDtoBuilder().WithResortId(resort.Id).Build();
        var cabin = new CabinCreateCommandBuilder().WithCabinCreateDto(cabinDto).Build();
        
        //var product = new CabinCreateDtoBuilder().WithProductCreateDto(productDto).Build();
        var jsonProduct = JsonSerializer.Serialize(cabin);
        var contentRequest = new StringContent(jsonProduct, Encoding.UTF8, "application/json"); 
        //When
        
        var response = await Client.PostAsync("/api/Cabin/Create",contentRequest,new CancellationToken() );


        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        //ovdje se mora proslijediti sta se ocekuje u responsu koji smo stavili u controleru a to je dto objekat
        var content = await response.Content.ReadFromJsonAsync<CabinDetailsDto>();
        content.Should().NotBeNull();
        
    }

    public CabinCreateTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}