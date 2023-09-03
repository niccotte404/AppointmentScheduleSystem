using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface IDbRequest<T>
    {
        Task<bool> AddAsync(T usingObject);
        Task<bool> DeleteAsync(T usingObject);
        Task<bool> UpdateAsync(T usingObject);
        Task<bool> SaveAsync();
    }
}
