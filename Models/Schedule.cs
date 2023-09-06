using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentScheduleSystem.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Company")] // [Key] annotation for foreign field
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public string Cabinet { get; set; }

        [ForeignKey("Date")] // [Key] annotation for foreign field
        public int? DateId { get; set; }
        public Date? Date { get; set; }

        [Required]
        public string Time { get; set; }
    }
}
