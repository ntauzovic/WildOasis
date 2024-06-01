using WildOasis.Domain.Entities;

namespace WildOasis.Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(string emailAddress, string firstName,string lastName,string phoneNumber, List<string> roles);
    Task<ApplicationUser?> GetUserAsync(string id);
    Task<ApplicationUser?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
}