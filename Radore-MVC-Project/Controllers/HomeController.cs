using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Radore_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index","Account");
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Status(int? code)
        {
            ViewBag.ErrorCode = code;
            return View();
        }
    }
}
