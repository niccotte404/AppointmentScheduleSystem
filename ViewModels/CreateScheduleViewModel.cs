using AppointmentScheduleSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentScheduleSystem.ViewModels
{
    public class CreateScheduleViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cabinet { get; set; }

        [ForeignKey("Date")]
        public int? DateId { get; set; }
        public Date? Date { get; set; }
        public string Time { get; set; }
    }
}
