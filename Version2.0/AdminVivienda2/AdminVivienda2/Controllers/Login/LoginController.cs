using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AdminVivienda2.Controllers.Login
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    //[RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/login/echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("api/login/echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Post()
        {
            return Ok();
        }
        [HttpPost]
        [Route("api/login/authenticate")]
        public IHttpActionResult Authenticate([FromBody]LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = (login.Password == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
