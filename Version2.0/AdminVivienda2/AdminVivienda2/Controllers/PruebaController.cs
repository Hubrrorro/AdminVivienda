using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminVivienda2.Controllers
{
    [Authorize]
    public class PruebaController : ApiController
    {
        [HttpGet]
        [Route("api/Prueba")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        [Route("api/Prueba")]
        public IHttpActionResult Post()
        {
            
            return Ok();
        }
    }
}
