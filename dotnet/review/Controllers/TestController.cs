using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using review.Models;

namespace review.Controllers
{
    public class TestController : Controller
    {
        //GET /Test
        public string Index()
        {
            return "This is a TestController";
        }
        public string LogInfo(String s)
        {
            return HtmlEncoder.Default.Encode($"Hello!, Your Information is {s}");
        }
    }
}
