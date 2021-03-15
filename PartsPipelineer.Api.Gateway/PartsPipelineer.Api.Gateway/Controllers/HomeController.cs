using Microsoft.AspNetCore.Mvc;

namespace PartsPipelineer.Api.Gateway.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Api Gateway is working!");
    }
}