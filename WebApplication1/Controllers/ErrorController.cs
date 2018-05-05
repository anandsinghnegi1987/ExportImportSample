using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult PageNotFoundException()
        {
            return View();
        }
    }
}