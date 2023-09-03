using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Interfaces;

namespace AppointmentScheduleSystem.Repositiry
{
    public class DbRequest<T> : IDbRequest<T>
    {
        private readonly AppDbContext _context;
        public DbRequest(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(T usingObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T usingObject)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(T usingObject)
        {
            throw new NotImplementedException();
        }
    }
}
