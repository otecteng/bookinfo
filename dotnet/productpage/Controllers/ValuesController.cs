using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using productpage.Models;
using System.Net;
using System.Net.NetworkInformation;
using System.Linq;
using System.Net.Sockets;
namespace productpage.Controllers
{
    [Authorize]
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICustomAuthenticationManager customAuthenticationManager;
        //private readonly IHttpContextAccessor httpContextAccessor;
        public ValuesController(ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
            //this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] {"value"};
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserCred userCred)
        {
            var token = customAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
