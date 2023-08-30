using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.Models
{
    public class Emploee // inherit from Identity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyId { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
