using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduleSystem.Repositiry
{
    public class ScheduleDbRequest : IScheduleDbRequest
    {
        private readonly AppDbContext _context;

        public ScheduleDbRequest(AppDbContext context)
        {
            _context = context; // create database response
        }

        public bool Add(Schedule usingObject)
        {
            _context.Add(usingObject);
            return Save();
        }

        public bool Delete(Schedule usingObject)
        {
            _context.Remove(usingObject);
            return Save();
        }

        public async Task<IEnumerable<Schedule>> GetAllByCompanyIdAsync(int id)
        {
            return await _context.Schedules.Where(elem => elem.CompanyId == id).ToListAsync(); // get by company id to match schedule with each company
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            return await _context.Schedules.Include(elem => elem.Date).ToListAsync(); // get all (used in Index)
        }

        public bool Save()
        {
            var requestResult = _context.SaveChanges();
            return requestResult > 0 ? true : false; // return true if response exists
        }

        public bool Update(Schedule usingObject)
        {
            _context.Update(usingObject);
            return Save();
        }
    }
}
