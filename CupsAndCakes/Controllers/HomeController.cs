using CupsAndCakes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CupsAndCakes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailProvider _emailProvider;

        public HomeController(ILogger<HomeController> logger, IEmailProvider emailProvider)
        {
            _logger = logger;
            _emailProvider = emailProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // The Support Email
        [HttpGet]
        public IActionResult Support()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Support(SupportEmail e)
        {
            // Sends email if model is valid
            if (ModelState.IsValid)
            {
                // Send email to sender indentity
                await _emailProvider.SendEmailAsync(e.Subject, e.Content);

                // Show success message on page
                ViewData["Message"] = "The email was sent successfully!";

                return View();
            }
            
            return View(e);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}