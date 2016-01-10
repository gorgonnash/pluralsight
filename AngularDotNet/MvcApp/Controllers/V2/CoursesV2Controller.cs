using MvcApp.Models.Courses;
using System.Web.Http;

namespace MvcApp.Controllers.V2
{
    public class CoursesV2Controller : ApiController
    {
        private readonly RegistrationVmBuilder _regBuilder = new RegistrationVmBuilder();

        [HttpGet]
        public CourseVm[] Get()
        {
            return _regBuilder.GetCourses();
        }
    }
}
