using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Web.Controllers
{
    public class BaseController : Controller
    {
        public string? GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
