using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Data.Enum;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleDbRequest _dbRequest;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            CreateScheduleViewModel createScheduleViewModel = new CreateScheduleViewModel();
            return View(createScheduleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleViewModel createScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                var schedule = new Schedule
                {
                    Title = createScheduleViewModel.Title,
                    Description = createScheduleViewModel.Description,
                    Cabinet = createScheduleViewModel.Cabinet,
                    Date = new Date
                    {
                        Day = createScheduleViewModel.Date.Day,
                        Month = createScheduleViewModel.Date.Month,
                        Year = createScheduleViewModel.Date.Year
                    },
                    Time = createScheduleViewModel.Time
                };
                _dbRequest.Add(schedule);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "failed to add model to db");
            }
            return View(createScheduleViewModel);
        }
    }
}
