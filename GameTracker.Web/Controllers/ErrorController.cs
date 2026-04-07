using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult NotFoundPage()
        {
            return View("404");
        }

        [Route("Error/500")]
        public IActionResult ServerError()
        {
            return View("500");
        }
    }
}
