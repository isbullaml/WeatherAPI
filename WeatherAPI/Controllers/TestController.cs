using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeatherAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet, Route("api/Test")]
        public IHttpActionResult Test()
        {
            return Ok("Test");
        }
    }
}
