using System.Diagnostics;
using System.Security.Claims;
using HCTKanban.Data;
using HCTKanban.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HCTKanban.Helpers;
using System.Text;

namespace HCTKanban.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
		private readonly ApplicationDbContext _context;
		
		public required string ReturnUrl { get; set; }

		public LoginController(ILogger<LoginController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			// Clear the existing external cookie
			await HttpContext.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Login");
		}

		[HttpGet]
		public IActionResult SetupUser()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		[HttpPost]
		public async Task<IActionResult> SetupUser(string Password)
		{
			var salt = HMACHelper.GenerateSalt();

			var hashedpassword = HMACHelper.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(Password), salt);

			ApplicationUser? user = _context.Users.Where(x => x.Salt == "temp").FirstOrDefault();
			if(user != null)
			{
				user.Salt = Convert.ToBase64String(salt);
				user.Password = Convert.ToBase64String(hashedpassword);
				_context.SaveChanges();
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string Password)
		
        {

			if (ModelState.IsValid)
			{
				// Use Input.Email and Input.Password to authenticate the user
				// with your custom authentication logic.
				//
				// For demonstration purposes, the sample validates the user
				// on the email address maria.rodriguez@contoso.com with 
				// any password that passes model validation.

				var user = await AuthenticateUser(Password);

				if (user == null)
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View();
				}

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Email),
					new Claim("Name", user.Name),
					new Claim(ClaimTypes.Role, "Administrator"),
				};

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					//AllowRefresh = <bool>,
					// Refreshing the authentication session should be allowed.

					//ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
					// The time at which the authentication ticket expires. A 
					// value set here overrides the ExpireTimeSpan option of 
					// CookieAuthenticationOptions set with AddCookie.

					//IsPersistent = true,
					// Whether the authentication session is persisted across 
					// multiple requests. When used with cookies, controls
					// whether the cookie's lifetime is absolute (matching the
					// lifetime of the authentication ticket) or session-based.

					//IssuedUtc = <DateTimeOffset>,
					// The time at which the authentication ticket was issued.

					//RedirectUri = <string>
					// The full path or absolute URI to be used as an http 
					// redirect response value.
				};

				await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);

				_logger.LogInformation("User {Email} logged in at {Time}.",
				user.Email, DateTime.UtcNow);

				return LocalRedirect("/home");
			}

			return View();

		}

		private async Task<ApplicationUser?> AuthenticateUser(string password)
		{

			ApplicationUser? user = await _context.Users.Where(x => x.UserId == 1).FirstOrDefaultAsync();
			if (user != null)
			{
				
				var saltbyte = Convert.FromBase64String(user.Salt);
				var checkpassword = HMACHelper.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(password), saltbyte);

				if (Convert.ToBase64String(checkpassword) == user.Password)
				{
					//authenticate
					return new ApplicationUser()
					{
						Email = user.Email,
						Name = user.Name
					};
				}
				
			}

			return null;

			
		}
	}
}
