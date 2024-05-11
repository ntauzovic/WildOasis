using Microsoft.AspNetCore.Identity;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Domain.Entities;

namespace WildOasis.Infrastructure.Identity;

public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{

    public async Task CreateRole(string role)
    {
        var alreadyExist = await roleManager.RoleExistsAsync(role);

        if (!alreadyExist)
        {
            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = role,
                NormalizedName = role.Normalize()
            });
        }
    }


}