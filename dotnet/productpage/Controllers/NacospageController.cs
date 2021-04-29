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
using Nacos.AspNetCore.V2;
using Nacos.AspNetCore;
namespace productpage.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class NacospageController : ControllerBase{
        private readonly INacosServerManager _svc;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHostingEnvironment _env;
        
    
        private readonly IConfiguration _configuration;
        public NacospageController(INacosServerManager svc,IHttpClientFactory httpClientFactory, IHostingEnvironment environment, IConfiguration configuration)
        {
            _svc = svc;
            _clientFactory = httpClientFactory;
            _env = environment;
            _configuration = configuration;
        }
        
        [HttpGet]
        public async Task<string> Get(int bookid)
        {
            var baseUrl = _svc.GetServerAsync("reviewservice").GetAwaiter().GetResult();

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                return "empty";
            }
            // else
            // {
            //     return baseUrl;
            // }
            var client = _clientFactory.CreateClient();
            
            client.BaseAddress = new Uri(baseUrl);
            
            //string result = await client.GetStringAsync("/");
            string result = await client.GetStringAsync("/Reviews/Detailsjson/" + bookid.ToString());
            result = result + "\n" + "This result is from:" + baseUrl.ToString();

            return result;
           
            
        }
        
    
    }
}