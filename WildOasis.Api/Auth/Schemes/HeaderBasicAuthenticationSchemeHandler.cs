using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using WilaOasis.Api.Auth.Options;
using WildOasis.Application.Common.Extensions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Configuration;

namespace WilaOasis.Api.Auth.Schemes;

public class HeaderBasicAuthenticationSchemeHandler : AuthenticationHandler<HeaderBasicAuthenticationSchemeOptions>
{
    private readonly IWildOasisDbContext _dbContext;
    private readonly AesEncryptionConfiguration _encryptionConfiguration;

    [Obsolete("Obsolete")]
    public HeaderBasicAuthenticationSchemeHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options,
        ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IOptions<AesEncryptionConfiguration> AesConfig) : base(options, logger, encoder, clock)
    {
        _encryptionConfiguration = AesConfig.Value;
    }

    public HeaderBasicAuthenticationSchemeHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options,
        ILoggerFactory logger, UrlEncoder encoder,  IOptions<AesEncryptionConfiguration> AesConfig) : base(options, logger, encoder)
    {
        _encryptionConfiguration = AesConfig.Value;

    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {

            var username = Request.Headers[Options.UsernameHeader].FirstOrDefault() ??
                           throw new InvalidOperationException("Missing username header");
            var password = Request.Headers[Options.PasswordHeader].FirstOrDefault() ??
                           throw new InvalidOperationException("Missing password header");
            var resort = Request.Headers[Options.ResortHeader].FirstOrDefault() ??
                          throw new InvalidOperationException("Missing resort header");

            
            var user = Options.Users.SingleOrDefault(user =>
                user.username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                user.password.Decrypt(_encryptionConfiguration.Key).Equals(password, StringComparison.OrdinalIgnoreCase) &&
                user.resort.Equals(resort, StringComparison.OrdinalIgnoreCase));

            var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, username) };
            claims.AddRange(user.Roles.Select(role=>new Claim(ClaimTypes.Role,role)));
            claims.AddRange(user.Claims.Select(x=>new Claim(x.Key,x.Value)));

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Token"));
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
        catch (Exception e)
        {
            return AuthenticateResult.Fail("Unauthorized");
        }
        
    }
}