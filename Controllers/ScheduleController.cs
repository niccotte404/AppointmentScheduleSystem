using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Data.Enum;
using AppointmentScheduleSystem.DataValidtion.Repository;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using EnumsNET;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleDbRequest _dbRequest;

        public ScheduleController(IScheduleDbRequest dbRequest)
        {
            _dbRequest = dbRequest;
        }

        public async Task<IActionResult> Index()
        {
            var schedule = await _dbRequest.GetAllAsync();
            return View(schedule);
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
                var monthInString = Enums.GetValues(typeof(Months)).Cast<Months>().Select(elem => elem.ToString()).ToList()[createScheduleViewModel.Date.Month];
                if (SimpleDateValidation.Validate(createScheduleViewModel.Date.Day, monthInString, createScheduleViewModel.Date.Year))
                {
                    var schedule = new Schedule
                    {
                        Title = createScheduleViewModel.Title,
                        Description = createScheduleViewModel.Description,
                        Cabinet = createScheduleViewModel.Cabinet,
                        Time = createScheduleViewModel.Time,
                        Date = new Date
                        {
                            Day = createScheduleViewModel.Date.Day,
                            Month = createScheduleViewModel.Date.Month, // здесь можно по идее сразу перевести enum значение в sring, но я заколебался туда сюда мотать бд
                            Year = createScheduleViewModel.Date.Year,
                        },
                        // add company
                    };
                    _dbRequest.Add(schedule);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "failed to add model to db");
            }
            return View(createScheduleViewModel);
        }
    }
}
