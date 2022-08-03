using CCMS.NEOPE.Application.ViewModels;
using CCMS.NEOPE.Infra.Identity;
using CCMS.NEOPE.Infra.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            var photoName = Guid.NewGuid().ToString() + photo.FileName;
            await using FileStream fileStream = new FileStream(Path.Combine(imageFolder, photoName), FileMode.Create);
            await photo.CopyToAsync(fileStream);
            viewModel.Photo = "~/Images/" + photoName;
        }
        
        ApplicationUser user = new ApplicationUser();
        IdentityResult userCreated;
            
        user.UserName = viewModel.UserName;
        user.FullName = viewModel.FullName;
        user.Code = viewModel.UserName;
        user.Photo = viewModel.Photo;
        user.IsActive = true;
            
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
        if (user != null && !user.IsActive) return View();
        
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
        else
        {
            ModelState.AddModelError("", "Usuário ou senha incorretos");
            return View(viewModel);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return RedirectToAction("Login");
    }

    public async Task<IActionResult> Profile()
    {
        return View();
    }
}