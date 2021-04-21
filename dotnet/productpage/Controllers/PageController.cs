using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using productpage.Models;
using System.Net.Http;

namespace productpage.Controllers
{
    public class PageController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public PageController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public string Index()
        {
            return "Product in docker";
        }
        public async Task<string> GetReview(int bookid)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("http://review:80/");
            //string result = await client.GetStringAsync("/");
            return await client.GetStringAsync("/Reviews/Detailsjson/" + bookid.ToString());
        }
    }
}
