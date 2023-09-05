using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface IScheduleDbRequest : IDbRequest<Schedule>
    {
        Task<IEnumerable<Schedule>> GetAllByCompanyIdAsync(int id);
        Task<IEnumerable<Schedule>> GetAllAsync();
    }
}
