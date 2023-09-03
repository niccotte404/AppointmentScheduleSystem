using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;

namespace AppointmentScheduleSystem.Repositiry
{
    public class CompanyDbRequest : ICompanyDbRequest
    {
        private readonly AppDbContext _context;
        public CompanyDbRequest(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Company usingObject)
        {
            _context.Add(usingObject);
            return Save();
        }

        public bool Delete(Company usingObject)
        {
            _context.Remove(usingObject);
            return Save();
        }

        public Task<IEnumerable<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetByAppUserIdAsync(string appUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(Company usingObject)
        {
            _context.Update(usingObject);
            return Save();
        }
    }
}
