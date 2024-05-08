using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.BaseTest.Builders.Domain;
using WildOasis.Domain.Entities;
using WildOasis.Domain.Enums;
using WildOasis.Infrastructure.Contexts;

namespace WildOasis.FunctionalTests.Cabins.Queries;

public class CabinDetailsQueryTests : BaseTests
{
    [Fact]
    public async Task CabinDetailsQueryTest_GivenValidCabinId_StatusOk()
    {

     
        //Given

        var resort = new ResortBuilder().Build();
        var cabin = new CabinBuilder().Build();
        cabin.AddResort(resort);
        await WildOasisDbContext.Cabins.AddAsync(cabin);
        await WildOasisDbContext.SaveChangesAsync();

        //When

        var response = await Client.GetAsync($"/api/Cabin/DetailsOne?Id={cabin.Id.ToString()}");



        //Then

        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        //ovdje se mora proslijediti sta se ocekuje u responsu koji smo stavili u controleru a to je dto objekat
        var content = await response.Content.ReadFromJsonAsync<CabinDetailsDto>();
        content!.Name.Should().Be(cabin.Name);
        content.Should().NotBeNull();
        content.ResortName.Should().Be(resort.Name);

    }

    [Fact]
    public async Task CabinDetailsQueryTest_GivenValidCabinIdAsNull_BadRequest()
    {

      
        //When

        var response = await Client.GetAsync($"/api/Cabin/DetailsOne");

        //Then

        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
       
    }
    
    [Fact]
    public async Task CabinDetailsQueryTest_GivenNotExistingCabinId_NotFound()
    {

       

        //Given

        var resort = new Resort("resort1", "restordescritpion","adress1234",123456789);
        var cabin = new Cabin("cabin12", "cabindescprtion", 3, 89, 10, "stringimages",Category.Bungalow);
        cabin.AddResort(resort);
        await WildOasisDbContext.Cabins.AddAsync(cabin);
        await WildOasisDbContext.SaveChangesAsync();

        //When

        var response = await Client.GetAsync($"/api/Product/Details?Id={Guid.NewGuid()}");

        //Then

        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

       
    }
    
    public CabinDetailsQueryTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}