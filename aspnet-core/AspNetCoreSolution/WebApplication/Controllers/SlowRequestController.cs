using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SlowRequestController : ControllerBase
    {
        private readonly ILogger _logger;

        public SlowRequestController(ILogger<SlowRequestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/slow")]
        public async Task<string> Get()
        {
            _logger.LogInformation("Starting to do slow work");
            await Task.Delay(10_000);
            var message = "Finished slow delay of 10 seconds";
            _logger.LogInformation(message);
            return message;
        }
    }
}