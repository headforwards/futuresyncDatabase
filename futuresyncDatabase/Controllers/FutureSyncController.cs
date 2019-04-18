using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace futuresyncDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureSyncController : ControllerBase
    {

        private const string api = "http://futuresyncspeakers.azurewebsites.net/api/speakers";

        // GET: api/FutureSync
        [HttpGet("tracks")]
        public IEnumerable<string> GetTracks()
        {
            var client = new WebClient();

            var data = client.DownloadString(api);

            var json = $"{{ speakers : {data}}}";

            var speakers = (JObject.Parse(json) as dynamic).speakers as IEnumerable<dynamic>;

            return speakers
                .Select(s => s.name.ToString())
                .Cast<string>();
        }
    }
}
