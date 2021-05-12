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
using StackExchange.Redis;
namespace productpage.Controllers
{
    [Authorize]
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICustomAuthenticationManager customAuthenticationManager;
        private readonly IDatabase database;
        
        public ValuesController(ICustomAuthenticationManager customAuthenticationManager, IDatabase database)
        {
            this.customAuthenticationManager = customAuthenticationManager;
            this.database = database;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value"};
        }

        [AllowAnonymous]
        [HttpGet("getfromredis")]
        public string GetFromRedis([FromQuery]string key)
        {
            return database.StringGet(key);
        }
        [AllowAnonymous]
        [HttpPost("settoredis")]
        public void SetToRedis([FromBody]KeyValuePair<string, string> keyValue)
        {
            database.StringSet(keyValue.Key, keyValue.Value);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserCred userCred)
        {
            var token = customAuthenticationManager.Authenticate(userCred.Username, userCred.Password, this.database);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
