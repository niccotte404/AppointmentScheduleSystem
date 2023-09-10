using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Enter surname")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Enter phone")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords doesn't equal")]
        public string ConfirmPassword { get; set; }
    }
}
