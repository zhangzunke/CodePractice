using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace MemeryCacheDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IDGCacheController : ControllerBase
    {
        private readonly IMemoryCache _memeryCache;
        private readonly IDistributedCache _distributedCache;
        public IDGCacheController(IMemoryCache memeryCache, IDistributedCache distributedCache)
        {
            _memeryCache = memeryCache;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public string Get()
        {
            _distributedCache.SetString("Age", "33");
            return _memeryCache.GetOrCreate<string>("IDKey", cacheEntry =>
            {
                return DateTime.Now.ToString();
            });
        }

        [HttpPost]
        public void Set()
        {
            _distributedCache.SetString("Age", "33");
        }
    }
}