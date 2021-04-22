using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using productpage.Models;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace productpage.Controllers
{
    public class CfgtestController : Controller
    {
        private IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public CfgtestController(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public string Index()
        {
            string flag = _configuration.GetValue<string>("test");
            if(flag.Equals("on"))
            {
                return "新功能开放";
            }
            else
            {
                return "新功能暂未开放";
            }

        }

        
    }
}
