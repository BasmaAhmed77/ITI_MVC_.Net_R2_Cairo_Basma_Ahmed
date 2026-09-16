using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.PL.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetCookie(int age, string fname)
        {
            Console.WriteLine("test");
            HttpContext.Response.Cookies.Append("age", age.ToString());
            HttpContext.Response.Cookies.Append("age", age.ToString(), new CookieOptions() { 
                Expires = DateTime.Now.AddMinutes(3)
            });
            HttpContext.Response.Cookies.Append("fname", fname);


            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1).AddMinutes(-5) 
            };
            return Content("");
            //return View();
        }
        public IActionResult GetCookie()
        {
            var age = int.Parse(HttpContext.Request.Cookies["age"]!);
            var fname = HttpContext.Request.Cookies["fname"];
            var org = HttpContext.Request.Cookies["org"];
            //return View();

            return Content($"age= {age}, fname= {fname}, middilewareCookie= {org}");
        }

        public IActionResult SetSession(int age, string lname)
        {
            HttpContext.Session.SetInt32("age", age);
            HttpContext.Session.SetString("lname", lname);
            //return View();
            return Content("");
        }
        public IActionResult GetSession()
        {
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"age: {age}");
            //return View();

        }




    }
}
