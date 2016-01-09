using MvcApp.Models.Courses;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly RegistrationVmBuilder _regBuilder = new RegistrationVmBuilder();

        public ActionResult Index()
        {
            return View("Index", string.Empty, _regBuilder.GetSerializedInstructors());
        }
    }
}