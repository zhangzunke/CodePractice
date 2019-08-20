using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeatureManagementDemo.Models;
using Microsoft.FeatureManagement;

namespace FeatureManagementDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureManager _featureManager;
        public HomeController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }
        public IActionResult Index()
        {
            var welcomeMessage = _featureManager.IsEnabled("NewWelcomeBanner")
                ? "Welcome to the Beta"
                : "Welcome";
            ViewBag.WelcomeMessage = welcomeMessage;
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
