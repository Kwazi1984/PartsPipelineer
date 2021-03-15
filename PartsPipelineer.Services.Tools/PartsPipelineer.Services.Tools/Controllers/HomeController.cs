using Microsoft.AspNetCore.Mvc;

namespace PartsPipelineer.Services.Tools.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Service Tools is working!");
    }
}