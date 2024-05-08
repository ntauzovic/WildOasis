using Microsoft.AspNetCore.Authentication;
using WildOasis.Application.Configuration;

namespace WilaOasis.Api.Auth.Options;

public class HeaderBasicAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public string UsernameHeader { get; set; } = "X-Wi-Username";
    public string PasswordHeader { get; set; } = "X-Wi-Password";
    public string ResortHeader { get; set; } = "X-Wi-Resort";
    //provjeriti dal ima veze veliko slovo

    public IEnumerable<HeaderBasicUserConfiguration> Users { get; init; } = Array.Empty<HeaderBasicUserConfiguration>();
}