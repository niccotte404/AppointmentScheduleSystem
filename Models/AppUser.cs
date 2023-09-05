using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentScheduleSystem.Models
{
    public class AppUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }

        [ForeignKey("Company")] // [Key] annotation for foreign field
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string? Department { get; set; }
    }
}
