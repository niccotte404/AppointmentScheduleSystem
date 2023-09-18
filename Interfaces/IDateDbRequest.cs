using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface IDateDbRequest
    {
        Task<Date> GetMonthById(int id);
    }
}
