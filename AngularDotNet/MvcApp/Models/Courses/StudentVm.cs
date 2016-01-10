using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models.Courses
{
    public class StudentVm
    {
        [Required(ErrorMessage = "Missing first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Missing last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Missing email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Missing password")]
        public string Password { get; set; }
    }
}