using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.Models
{
    public class Date
    {
        [Key]
        public int Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
