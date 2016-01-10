using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace MvcApp.Models.Courses
{
    public class RegistrationVmBuilder
    {
        public RegistrationVm BuildRegistrationVm()
        {
            return new RegistrationVm
            {
                Courses = GetSerializedCourses(),
                Instructors = GetSerializedInstructors()
            };
        }

        public CourseVm[] GetCourses() 
        {
            return new[]
            {
                new CourseVm { Name = "C Class 101", Number = "C101", Instructor = "I01" },
                new CourseVm { Name = "B Class 102", Number = "B102", Instructor = "I02" },
                new CourseVm { Name = "A Class 301", Number = "A301", Instructor = "I03" },
            };
        }

        public string GetSerializedCourses() 
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(GetCourses(), Formatting.None, settings);
        }

        public InstructorVm[] GetInstructors() 
        {
            return new[]
            {
                new InstructorVm { Name = "I01", Email = "I0001@test.com", RoomNumber = 1001 },
                new InstructorVm { Name = "I02", Email = "I002@test.com", RoomNumber = 105 },
                new InstructorVm { Name = "I03", Email = "I03@test.com", RoomNumber = 102 }
            };
        }

        public string GetSerializedInstructors()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(GetInstructors(), Formatting.None, settings);
        }
    }
}