using System.Web.Mvc;

namespace _2K.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}