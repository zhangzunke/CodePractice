using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using WebApplication.IOC;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger<ValuesController>();
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var typeList = typeof(List<>);
            Type typeDataList = typeList.MakeGenericType(typeof(DateTime));

            _logger.LogInformation("IOC Test ...........");
            _logger.LogInformation(ReferenceEquals(_serviceProvider.GetService<ITransientTest>(),
                _serviceProvider.GetService<ITransientTest>()).ToString());

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Michael"),
                new Claim(ClaimTypes.NameIdentifier, "111")
            };

            var identity = new ClaimsIdentity(claims, "Cookies");

            var identityPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", identityPrincipal);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
