using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GoDelivery.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] // prevents Swagger from breaking
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem(
                statusCode: 500,
                title: "Internal Server Error"
            );
        }

        [Route("/error-development")]
        public IActionResult ErrorDevelopment(
            [FromServices] IWebHostEnvironment env,
            [FromServices] ILogger<ErrorController> logger)
        {
            if (!env.IsDevelopment())
                return Error();

            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            logger.LogError(exception, "Unhandled exception occurred");

            return Problem(
                statusCode: 500,
                title: exception?.Message,
                detail: exception?.StackTrace
            );
        }
    }
}
