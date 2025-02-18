using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShop.Mvc.Models;

namespace EShop.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
