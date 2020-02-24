using Microsoft.AspNetCore.Mvc;
using MvcSockets.Models;

namespace MvcSockets.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Hello(string name, string greeting = "Hello")
        {
            if (name == null)
            {
                name = HttpContext.Request.Cookies.TryGetValue("name", out var nameFromCookie)
                    ? nameFromCookie
                    : "World";
            }
            else
            {
                HttpContext.Response.Cookies.Append("name", name);
            }

            return View(new HelloModel
            {
                Greeting = greeting,
                Name = name
            });
        }

        public IActionResult Time()
        {
            return View();
        }
    }
}
