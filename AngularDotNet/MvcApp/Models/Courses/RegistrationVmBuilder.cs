using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        public string GetSerializedCourses() 
        {
            var courses = new[]
            {
                new CourseVm { Name = "C Class 101", Number = "C101", Instructor = "I01" },
                new CourseVm { Name = "B Class 102", Number = "B102", Instructor = "I02" },
                new CourseVm { Name = "A Class 301", Number = "A301", Instructor = "I03" },
            };

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(courses, Formatting.None, settings);
        }

        public string GetSerializedInstructors()
        {
            var instructors = new[]
            {
                new InstructorVm { Name = "I01", Email = "I0001@test.com", RoomNumber = 1001 },
                new InstructorVm { Name = "I02", Email = "I002@test.com", RoomNumber = 105 },
                new InstructorVm { Name = "I03", Email = "I03@test.com", RoomNumber = 102 }
            };

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(instructors, Formatting.None, settings);
        }
    }
}