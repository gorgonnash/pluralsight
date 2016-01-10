using MvcApp.Models.Courses;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class CoursesController : JsonController
    {
        private readonly RegistrationVmBuilder _regBuilder = new RegistrationVmBuilder();

        public ActionResult Index()
        {
            return Json2(_regBuilder.GetCourses(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index2()
        {
            return View("Index",string.Empty, _regBuilder.GetSerializedCourses());
        }        
    }    
}