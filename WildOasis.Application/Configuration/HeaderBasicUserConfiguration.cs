namespace WildOasis.Application.Configuration;

public class HeaderBasicUserConfiguration
{
    public string username { get; init; } = null!;
    public string password { get; init; } = null!;
    public string resort { get; init; } = null!;

    public string[] Roles { get; init; } = Array.Empty<string>();
    public Dictionary<string, string> Claims { get; init; } = new Dictionary<string, string>();
}