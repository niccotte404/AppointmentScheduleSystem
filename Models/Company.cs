using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.Models
{
    public class Company // inherit from Identity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
