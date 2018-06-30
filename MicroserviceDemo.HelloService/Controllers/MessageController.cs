using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MicroserviceDemo.HelloService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet("")]
        [Produces("text/plain"), ProducesResponseType(200, Type = typeof(string))]
        [Authorize, EnableCors("SPAClient")]
        public ActionResult<string> Hello()
        {
            return $"Hello from .NET Core Service at {DateTime.Now}";
        }
    }
}