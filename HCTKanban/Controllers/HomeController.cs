using System.Diagnostics;
using HCTKanban.Data;
using HCTKanban.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCTKanban.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            if (_httpContext.HttpContext != null && _httpContext.HttpContext.User.Identity != null) {
                if (_httpContext.HttpContext.User.Identity.IsAuthenticated!) { 
                
                 return View();
                }            
            } 
                return RedirectToAction("login", "login");        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		//[HttpGet]
		//public void HelloWorld()
		
  //      {

  //              Locations newlocation = new Locations() { LocationName = "Hello World" };

		//	    _context.Locations.Add(newlocation);

		//	    _context.SaveChanges();		

		//}
	}
}
