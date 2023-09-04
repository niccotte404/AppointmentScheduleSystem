using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Data.Enum;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleViewModel createScheduleViewModel)
        {
            return View();
        }

        private async Task<bool> IsDayValid(int day, string month, int year)
        {
            IEnumerable<string> months = new[] { "January", "March", "May", "July", "August", "October", "December" };
            if (day < 1 || day > 31 || year < 2023)
            {
                return false;
            }
            else if (day > 30 && months.FirstOrDefault(elem => elem == month) == null)
            {
                return false;
            }
            else if (day > 28 && month == "February")
            {
                return false;
            }
            return true;
        }

    }
}
