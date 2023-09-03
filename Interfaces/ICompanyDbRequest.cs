using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface ICompanyDbRequest : IDbRequest<Company>
    {
        Task<Company> GetByIdAsync(string id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByNameAsync (string name);
        Task<IEnumerable<Company>> GetByAppUserIdAsync(string appUserId);
    }
}
