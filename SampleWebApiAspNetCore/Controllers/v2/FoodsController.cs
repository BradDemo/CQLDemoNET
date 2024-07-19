using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace SampleWebApiAspNetCore.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FoodsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("2.0");
        }

        // Existing Search method...

        // Introducing a potential XSS issue: Directly reflecting user input back in the response
        [HttpGet("reflect")]
        public ActionResult Reflect(string input)
        {
            // Directly using user input in the HTTP response without sanitization
            // In a real application, always validate and encode user inputs to prevent XSS
            return Content($"You entered: {input}");
        }
    }
}