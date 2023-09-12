using System.Collections;
using System.Security.Claims;
using AppointmentScheduleSystem.Data.Enum;
using AppointmentScheduleSystem.DataValidtion.ValidateModels;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using EnumsNET;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleDbRequest _scheduleDbRequest; // db request ot schedule table
        private readonly ICompanyDbRequest _companyDbRequest; // db request ot company table
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ScheduleController(IScheduleDbRequest scheduleDbRequest, ICompanyDbRequest companyDbRequest, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _scheduleDbRequest = scheduleDbRequest;
            _companyDbRequest = companyDbRequest;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Schedule> schedule = new List<Schedule>(); // init main schedule
            
            if (_signInManager.IsSignedIn(User)) // is user authorised
            {
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); // get user id with context accessor
                IEnumerable<Company> companies = await _companyDbRequest.GetByAppUserIdAsync(userId); // get company list of current user
                
                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                // change companies to user (not only to owner)
                
                foreach (var company in companies)
                {
                    IEnumerable<Schedule> companySchedule = await _scheduleDbRequest.GetAllByCompanyIdAsync(company.Id); // get schedule of current company
                    // the complexity of algorithm is O(n) 'cause there is very view amount of companies
                    foreach (var meeting in companySchedule)
                    {
                        schedule.Append(meeting); // add meeting to main schedule
                    }
                }

                return View(schedule);
            }
            return View(schedule); // send them to view
        }

        public async Task<IActionResult> Create()
        {
            CreateScheduleViewModel createScheduleViewModel = new CreateScheduleViewModel();
            // attach to company here -----
            return View(createScheduleViewModel);
        }

        // get post request
        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleViewModel createScheduleViewModel)
        {
            if (ModelState.IsValid) // model validation
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
                    }
                    // add company
                }; // map
                _scheduleDbRequest.Add(schedule);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to add model to db");
            }
            return View(createScheduleViewModel);
        }
    }
}
