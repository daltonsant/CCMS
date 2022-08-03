using CCMS.NEOPE.Infra.Identity;
using Microsoft.AspNetCore.Identity;

namespace CCMS.NEOPE.Infra.Interfaces;

public interface IUserService
{
    Task<IdentityResult> CreateUser(ApplicationUser user, string password);
    Task AddUserInRole(ApplicationUser user, string role);
    bool VerifyIfHasRegisteredUsers();
    Task LoginUser(ApplicationUser user, bool isToRemember);
    Task<ApplicationUser> GetUserByUserName(string username);
    Task Logout();
}