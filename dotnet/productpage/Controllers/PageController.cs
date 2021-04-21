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
    public class PageController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;
        public PageController(IHttpClientFactory clientFactory,IHostingEnvironment environment, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _env = environment;
            _configuration = configuration;
        }
        public string Index()
        {
            if(_env.IsDevelopment())
            {
                return "Dev env";
            }
            else
            {
                return "Your are in the Production env" ;
            }
            
        }
        public async Task<string> GetReview(int bookid)
        {
            var client = _clientFactory.CreateClient();
            if(_env.IsDevelopment())
            {
                client.BaseAddress = new Uri("http://localhost:5001/");
                //string result = await client.GetStringAsync("/");
                return await client.GetStringAsync("/Reviews/Detailsjson/" + bookid.ToString());
            }
            else
            {
                client.BaseAddress = new Uri("http://review:80/");
                //string result = await client.GetStringAsync("/");
                return await client.GetStringAsync("/Reviews/Detailsjson/" + bookid.ToString());
            }
            
        }

       
    }
}
