using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface IDbRequest<T>
    {
        bool Add(T usingObject);
        bool Delete(T usingObject);
        bool Update(T usingObject);
        bool Save();
    }
}
