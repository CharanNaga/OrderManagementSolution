using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            // Log the exception or perform any additional error handling here such as redirecting to error page in UI

            // Return a custom error response
            return Problem(
                detail: exception.Message,
                title: "An error occurred",
                statusCode: 500
            );
        }
    }
}
