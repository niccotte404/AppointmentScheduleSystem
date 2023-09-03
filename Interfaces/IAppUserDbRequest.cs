using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface IAppUserDbRequest : IDbRequest<AppUser>
    {
        Task<AppUser> GetByIdAsync(string id);
    }
}
