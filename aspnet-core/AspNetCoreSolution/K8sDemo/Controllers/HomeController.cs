using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using K8sDemo.Models;
using System.Net;
using System.Net.Sockets;

namespace K8sDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var hostName = Dns.GetHostName();
            ViewBag.HostName = hostName;
            ViewBag.HostIp = Dns.GetHostAddresses(hostName).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CheckHealth()
        {
            if (new Random().Next(100) > 50)
            {
                return Ok("OK");
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
