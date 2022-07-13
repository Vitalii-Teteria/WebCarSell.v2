using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebCarSell.DataAccess.Context;
using WebCarSell.DataAccess.Entities;
using WebCarSell.Models;

namespace WebCarSell.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context, RoleManager<IdentityRole> roleManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView) 
        {
            if (ModelState.IsValid)
            {
                User user = new User() { UserName = registerView.Login, SName = registerView.SName, Email = registerView.Email, Roles=registerView.Roles, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, registerView.Password);
                if (result.Succeeded)
                {
                    if (user.Roles == "User") 
                    {
                        _userManager.AddToRoleAsync(user, "User").Wait();
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registerView);
        }

        //[HttpGet]
        //public IActionResult Login(string? returnUrl = null) 
        //{
        //    return View(new LoginViewModel { ReturnUrl = returnUrl });
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Login, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(viewModel.ReturnUrl) && Url.IsLocalUrl(viewModel.ReturnUrl))
                    {
                        return Redirect(viewModel.ReturnUrl);
                    }
                    else
                    {
                        var user = _context.Users.FirstOrDefault(u => u.UserName==viewModel.Login);
                        if (user == null)
                        {
                            return StatusCode(401);
                        }
                        else 
                        {
                            var token = CreateJwtToken(user.Roles);
                            HttpContext.Session.SetString("Token", token);
                            return RedirectToAction("Index", "Home");
                      }
                    }
                }
                else ModelState.AddModelError("", "Wrong login or password");
            }
            return View();
        }

        private string CreateJwtToken(string role)
        {
          
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Role, role)            
            };         
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(3)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Profile() 
        {
            return View();
        }
    }
}
