using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.Models
{
    public class Company
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
    }
}
