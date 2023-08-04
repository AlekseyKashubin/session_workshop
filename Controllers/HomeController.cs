using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using session_workshop.Models;

namespace session_workshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("Login")]
    public IActionResult Login(string UserName)
    {

        HttpContext.Session.SetString("UserName", UserName);
        HttpContext.Session.SetInt32("Counter", 0);
        return RedirectToAction("Dashboard");
    }


    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserName") == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View();
    }

    [HttpGet("addOne/{plusOne}")]
    public IActionResult AddOne(string plusOne)
    {
            
            int IntVariable = Convert.ToInt32(HttpContext.Session.GetInt32("Counter"));
            IntVariable += 1;
            HttpContext.Session.SetInt32("Counter", IntVariable);
            return RedirectToAction("Dashboard");
        
    }

    [HttpGet("subOne/{minusOne}")]
    public IActionResult SubOne(string minusOne)
    {
            int IntVariable = Convert.ToInt32(HttpContext.Session.GetInt32("Counter"));
            IntVariable -= 1;
            HttpContext.Session.SetInt32("Counter", IntVariable);
            return RedirectToAction("Dashboard");
    }


[HttpGet("timesTwo/{multiplyByTwo}")]
    public IActionResult TimesTwo(string multiplyByTwo)
    {
        
            int IntVariable = Convert.ToInt32(HttpContext.Session.GetInt32("Counter"));
            IntVariable *= 2;
            HttpContext.Session.SetInt32("Counter", IntVariable);
            return RedirectToAction("Dashboard");
    }

    [HttpGet("random/{plusRandom}")]
    public IActionResult RandomAdd(string plusRandom)
    {
        Random rand = new Random();

            int IntVariable = Convert.ToInt32(HttpContext.Session.GetInt32("Counter"));
            IntVariable += rand.Next(1, 11);
            HttpContext.Session.SetInt32("Counter", IntVariable);
            return RedirectToAction("Dashboard");
        
    }


    [HttpGet("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
}
