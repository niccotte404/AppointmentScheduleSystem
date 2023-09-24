using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduleSystem.Repositiry
{
    public class CompanyDbRequest : ICompanyDbRequest
    {
        private readonly AppDbContext _context;

        public CompanyDbRequest(AppDbContext context)
        {
            _context = context; // create database context response
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

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync(); // get all companies (used in Index)
        }

        public async Task<IEnumerable<Company>> GetByAppUserIdAsync(string appUserId)
        {
            return await _context.Companies.Where(i => i.AppUserId == appUserId).ToListAsync(); // get by app user id to math company with creator
        }

        public async Task<Company> GetByIdAsync(int? id)
        {
            return await _context.Companies.FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<Company> GetByNameAsync(string name)
        {
            return await _context.Companies.FirstOrDefaultAsync(i => i.Name == name);
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false; // return true if response exists
        }

        public bool Update(Company usingObject)
        {
            _context.Update(usingObject);
            return Save();
        }
    }
}
