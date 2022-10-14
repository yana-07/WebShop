using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (TempData.ContainsKey("LastAccessTime"))
            //{
            //    TempData.Keep("LastAccessTime"); -> will keep the cookie after being read
            //    TempData.Peek("LastAccessTime"); -> will also keep the cookie
            //    return Ok(TempData["LastAccessTime"]); // -> cookie expires after being read
            //}

            //TempData["LastAccessTime"] = DateTime.Now;
            //TempData["SecondAccessTime"] = DateTime.Now.AddHours(1);
            //TempData["ThirdAccessTime"] = DateTime.Now.AddHours(2);
            //this.HttpContext.Response.Cookies.Append("myCookie", "Pesho", new CookieOptions
            //{

            //});

            this.HttpContext.Session.SetString("name", "Pesho");

            return View();
        }

        public IActionResult Privacy()
        {
            string? name = this.HttpContext.Session.GetString("name");

            if (!string.IsNullOrEmpty(name))
            {
                return Ok(name);
            }

            return View();           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}