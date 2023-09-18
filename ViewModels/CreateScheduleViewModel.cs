using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.ViewModels
{
    public class CreateScheduleViewModel
    {
        // set params that often used to match view and model (database)
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cabinet { get; set; }
        public Date? Date { get; set; }
        public string Time { get; set; }
        public int? CompanyId { get; set; }
    }
}
