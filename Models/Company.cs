using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentScheduleSystem.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }

        [ForeignKey("AppUser")] // [Key] annotation for foreign field
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
