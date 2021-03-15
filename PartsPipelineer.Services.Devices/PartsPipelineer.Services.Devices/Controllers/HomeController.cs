using Microsoft.AspNetCore.Mvc;

namespace PartsPipelineer.Services.Devices.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Service Devices is working!");
    }
}