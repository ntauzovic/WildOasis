using Demo.Auth.Constants;
using WilaOasis.Api.Auth.Options;
using WilaOasis.Api.Auth.Schemes;

namespace WilaOasis.Api.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddWildOasisAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthenticationSchemeOptions, HeaderBasicAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header")
                    //configuration.GetSection zna da treba da podje u appsettings i da iz njega procita Auth headers
                    .Bind(schemeOptions));
        
        // services.AddAuthentication()
        //     .AddScheme<JwtAuthenticationSchemeOptions, JwtAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
        //         schemeOptions => configuration.GetSection("Auth:Header")
        //             .Bind(schemeOptions));

        return services;
    }
}