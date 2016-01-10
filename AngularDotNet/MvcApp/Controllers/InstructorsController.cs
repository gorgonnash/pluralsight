using MvcApp.Models.Courses;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class InstructorsController : JsonController
    {
        private readonly RegistrationVmBuilder _regBuilder = new RegistrationVmBuilder();

        public ActionResult Index()
        {
            return Json2(_regBuilder.GetInstructors(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index2()
        {
            return View("Index", string.Empty, _regBuilder.GetSerializedInstructors());
        }
    }
}