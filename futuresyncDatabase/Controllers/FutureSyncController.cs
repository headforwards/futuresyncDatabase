using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using futuresyncDatabase.Models;
using futuresyncDatabase.Providers;
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

        private readonly IWebClientProvider webClientProvider;

        public FutureSyncController(IWebClientProvider webClientProvider)
        {
            this.webClientProvider = webClientProvider;
        }

        private IEnumerable<dynamic> rawData = null;

        private IEnumerable<dynamic> GetRawData()
        {
            if (rawData == null)
            {

                var client = webClientProvider.WebClient();

                var data = client.DownloadString(api);

                var json = $"{{ speakers : {data}}}";

                rawData = (JObject.Parse(json) as dynamic).speakers as IEnumerable<dynamic>;
            }

            return rawData;
        }


        // GET: api/FutureSync
        [HttpGet("tracks")]
        public IEnumerable<string> GetTracks()
        {
            var speakers = GetRawData();

            return speakers
                .Select(s => s.track.ToString())
                .Cast<string>()
                .Distinct();
        }

        [HttpGet("speakers")]
        public IEnumerable<Speaker> GetSpeakers()
        {
            var speakers = GetRawData();

            return speakers
                .Select(s => new Speaker
                {
                    Name = s.name.ToString(),
                    Description = s.description.ToString()
                })
                .Distinct();
        }
    }
}
