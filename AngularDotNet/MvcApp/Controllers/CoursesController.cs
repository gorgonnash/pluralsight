using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View("Index",string.Empty, GetSerializedCourses());
        }

        public string GetSerializedCourses()
        {
            var courses = new[]
            {
                new CourseVm { Name = "C Class 101", Number = "C101", Instructor = "I01" },
                new CourseVm { Name = "B Class 102", Number = "B102", Instructor = "I02" },
                new CourseVm { Name = "A Class 301", Number = "A301", Instructor = "I03" },
            };

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(courses, settings);
        }
    }

    public class CourseVm
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public string Instructor { get; set; }    
    }
}