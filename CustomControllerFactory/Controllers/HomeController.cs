using System.Web.Mvc;

namespace CustomControllerFactory.Controllers
{
    public class HomeController : Framework.Controllers.HomeController
    {
        // GET: Home
        public ActionResult SomeOtherAction()
        {
            ViewBag.Controller = GetType().FullName;
            return View();
        }
    }
}