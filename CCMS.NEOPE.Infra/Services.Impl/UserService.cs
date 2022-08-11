using CCMS.NEOPE.Infra.Data.Context;
using CCMS.NEOPE.Infra.Identity;
using CCMS.NEOPE.Infra.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CCMS.NEOPE.Infra.Services.Impl;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationContext _context;

    public UserService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task AddUserInRole(ApplicationUser user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public bool VerifyIfHasRegisteredUsers()
    {
        return _context.Set<ApplicationUser>().Any();
    }

    public async Task LoginUser(ApplicationUser user, bool isToRemember)
    {
        await _signInManager.SignInAsync(user, isToRemember);
    }

    public async Task<ApplicationUser?> GetUserByUserName(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
    {
        return _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public Task<IdentityResult> UpdateUser(ApplicationUser user)
    {
        return _userManager.UpdateAsync(user);
    }

    public IQueryable<ApplicationUser> Users
    {
        get
        {
            return _context.Set<ApplicationUser>().AsQueryable();
        }
    }
}