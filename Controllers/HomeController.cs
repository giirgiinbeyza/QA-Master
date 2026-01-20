using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DermaLogic.Models;
using DermaLogic.Data; 
using Microsoft.AspNetCore.Authorization;

namespace DermaLogic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; 

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
            

                try 
                {
                    
                    ViewBag.TotalTests = _context.TestCases.Count();
                    ViewBag.PassTests = _context.TestCases.Count(t => t.Status == "Başarılı" || t.Status == "Pass");
                    ViewBag.FailTests = _context.TestCases.Count(t => t.Status == "Hatalı" || t.Status == "Fail");
                    ViewBag.NotRunTests = _context.TestCases.Count(t => t.Status == "Koşulmadı" || t.Status == "Not Run");
                }
                catch
                {
                    
                    ViewBag.TotalTests = 0;
                    ViewBag.PassTests = 0;
                    ViewBag.FailTests = 0;
                    ViewBag.NotRunTests = 0;
                }

                
                return View(); 
            }

            
            return View();
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
}