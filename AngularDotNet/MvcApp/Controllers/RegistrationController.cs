using MvcApp.Models.Courses;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationVmBuilder _regBuilder = new RegistrationVmBuilder();

        public ActionResult Index()
        {
            return View(_regBuilder.BuildRegistrationVm());
        }
    }
}