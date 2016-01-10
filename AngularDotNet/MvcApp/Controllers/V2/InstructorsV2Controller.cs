using MvcApp.Models.Courses;
using System.Web.Http;

namespace MvcApp.Controllers.V2
{
    public class InstructorsV2Controller : ApiController
    {
        private readonly RegistrationVmBuilder _regBuilder = new RegistrationVmBuilder();

        [HttpGet]
        public InstructorVm[] Get()
        {
            return _regBuilder.GetInstructors();
        }
    }
}
