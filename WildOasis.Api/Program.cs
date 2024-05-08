using WilaOasis.Api.Auth;
using WilaOasis.Api.Filters;
using WildOasis.Application;
using WildOasis.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options=>options.Filters.Add<ApiExceptionFilterAttribute>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddWildOasisAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

public partial class Program
{
}