using CCMS.NEOPE.Application.ViewModels;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Infra.Identity;
using CCMS.NEOPE.Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace CCMS.NEOPE.Web.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UsersController(
        IUserService userService,
        IWebHostEnvironment webHostEnvironment)
    {
        _userService = userService;
        _webHostEnvironment = webHostEnvironment;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel, IFormFile? photo)
    {
        if (!ModelState.IsValid) return View(viewModel);
        
        if(photo != null)
        {
            viewModel.Photo = await CreatePhoto(photo);
        }
        
        ApplicationUser user = new ApplicationUser();
        IdentityResult userCreated;
            
        user.UserName = viewModel.UserName;
        user.FirstName = viewModel.FirstName;
        user.LastName = viewModel.LastName;
        user.Email = viewModel.Email;
        user.Code = viewModel.UserName;
        user.Photo = viewModel.Photo;
        user.IsActive = true;

        Accountable accountable = new Accountable()
        {
            DisplayName = user.FirstName + " " + user.LastName,
            Code = user.Code,
            User = user
        };
        user.Accountable = accountable;
            
        if(!_userService.VerifyIfHasRegisteredUsers())
        {
            userCreated = await _userService.CreateUser(user, viewModel.Password);

            if (userCreated.Succeeded)
            {
                await _userService.AddUserInRole(user, "Administrator");
                await _userService.LoginUser(user, false);
                return RedirectToAction("Index", "Home");
            }
        }

        userCreated = await _userService.CreateUser(user, viewModel.Password);

        if (userCreated.Succeeded)
        {
            await _userService.AddUserInRole(user, "User");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            foreach(IdentityError error in userCreated.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(viewModel);
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid) return View();
        
        var user = await _userService.GetUserByUserName(viewModel.UserName);
        
        if (user == null)
        {
            ModelState.AddModelError("", "Usuário ou senha incorretos");
            return View(viewModel);
        }
        
        PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

        if (passwordHasher
                .VerifyHashedPassword(user, 
                    user.PasswordHash, 
                    viewModel.Password) !=
            PasswordVerificationResult.Failed)
        {
            await _userService.LoginUser(user, false);
            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("", "Usuário ou senha incorretos");
        return View(viewModel);
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return RedirectToAction("Login");
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Profile(EditProfileViewModel viewModel, IFormFile? photo)
    {
        if (!string.IsNullOrEmpty(viewModel.Password) && string.IsNullOrEmpty(viewModel.OldPassword))
        {
            ModelState.AddModelError("OldPassword","A senha atual é obrigatória");
        }

        if (!ModelState.IsValid) return View(viewModel);
        
        var currentUser = await _userService.GetUserByUserName(User.Identity?.Name ?? string.Empty);

        if (currentUser == null) return View(viewModel);

        if (!string.IsNullOrEmpty(viewModel.Password) && !string.IsNullOrEmpty(viewModel.OldPassword))
        {
            var result =
                await _userService.ChangePasswordAsync(currentUser, viewModel.OldPassword,
                    viewModel.Password);
            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", " * " +error.Description);
                }
                return View(viewModel);
            }
        }

        if(currentUser.Accountable != null){
            currentUser.Accountable.DisplayName = currentUser.FirstName + " " + currentUser.LastName;
        }

        if (photo == null) return RedirectToAction("Index", "Home");
        
        if (string.IsNullOrEmpty(currentUser.Photo))
        {
            currentUser.Photo = await CreatePhoto(photo);
            await _userService.UpdateUser(currentUser);
        }
        else
        {
            await using FileStream fileStream = new FileStream(Path.Combine("",currentUser.Photo), FileMode.Create);
            await photo.CopyToAsync(fileStream);
        }

        return RedirectToAction("Index", "Home");
    }
    
    private async Task<string> CreatePhoto(IFormFile? photo)
    {
        var imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
        var photoName = Guid.NewGuid().ToString() + photo.FileName;
        await using FileStream fileStream = new FileStream(Path.Combine(imageFolder, photoName), FileMode.Create);
        await photo.CopyToAsync(fileStream);
        return "/Images/" + photoName;
    }
}