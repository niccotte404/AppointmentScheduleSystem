using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduleSystem.Repositiry
{
    public class DateDbRequest : IDateDbRequest
    {
        private readonly AppDbContext _context;
        public DateDbRequest(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Date> GetDateById(int? id)
        {
            if (id is not null)
            {
                return await _context.Dates.FirstOrDefaultAsync(elem => elem.Id == id);
            }
            return null;
        }
    }
}
