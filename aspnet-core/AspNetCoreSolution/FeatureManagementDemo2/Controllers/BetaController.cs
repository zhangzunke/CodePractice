using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureManagementDemo2.Controllers
{
    [FeatureGate(FeatureFlags.Beta)]
    public class BetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}