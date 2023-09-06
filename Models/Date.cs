using AppointmentScheduleSystem.DataValidtion.ValidateModels;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.Models
{
    [DateValidation]
    public class Date
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
