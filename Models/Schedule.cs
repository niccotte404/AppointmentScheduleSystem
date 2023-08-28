using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentScheduleSystem.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cabinet { get; set; }

        [ForeignKey("Date")]
        public Date Date { get; set; }
        public string Time { get; set; }
    }
}
