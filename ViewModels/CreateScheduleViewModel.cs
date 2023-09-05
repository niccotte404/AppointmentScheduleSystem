using AppointmentScheduleSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentScheduleSystem.ViewModels
{
    public class CreateScheduleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cabinet { get; set; }
        public Date? Date { get; set; }
        public string Time { get; set; }
    }
}
