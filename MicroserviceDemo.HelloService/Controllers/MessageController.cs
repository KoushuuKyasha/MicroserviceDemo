using Microsoft.AspNetCore.Mvc;
using System;

namespace MicroserviceDemo.HelloService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult<string> Index()
        {
            return $"Hello from .NET Core Service at {DateTime.Now}";
        }
    }
}