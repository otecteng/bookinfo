using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace productpage.Controllers
{
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        private IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public IActionResult Get(string key)
        {
            string title = _configuration.GetValue<string>(key);

            return Json(title);
        }
    }
}
