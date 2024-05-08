using Microsoft.AspNetCore.Identity;

namespace WildOasis.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public IList<ApplicationUserRole> UserRoles { get; set; } //zasto ovdje imamo IList o ApplicationUserRole
};