using Microsoft.AspNetCore.Identity;

namespace WildOasis.Domain.Entities;

public class ApplicationUser : IdentityUser
{
 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public IList<ApplicationUserRole> Roles { get; } =
        new List<ApplicationUserRole>();
}