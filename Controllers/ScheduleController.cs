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
using Microsoft.IdentityModel.Tokens;

namespace AppointmentScheduleSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleDbRequest _scheduleDbRequest; // db request ot schedule table
        private readonly ICompanyDbRequest _companyDbRequest; // db request ot company table
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDateDbRequest _dateDbRequest;
        public ScheduleController(IScheduleDbRequest scheduleDbRequest, ICompanyDbRequest companyDbRequest, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IDateDbRequest dateDbRequest)
        {
            _scheduleDbRequest = scheduleDbRequest;
            _companyDbRequest = companyDbRequest;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _dateDbRequest = dateDbRequest;
        }

        public async Task<IActionResult> Index()
        {
            List<Schedule> schedule = new List<Schedule>(); // init main schedule

            if (_signInManager.IsSignedIn(User)) // is user authorised
            {
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); // get user id with context accessor
                AppUser appUser = await _signInManager.UserManager.FindByIdAsync(userId); // get user id with context accessor
                Company company = await _companyDbRequest.GetByIdAsync(appUser.CompanyId); // get company list of current user
                
                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                // change companies to user (not only to owner) => make matching user with company by search
                
                if (company is null)
                {
                    return RedirectToAction("Index", "Company");
                }

                IEnumerable<Schedule> companySchedule = await _scheduleDbRequest.GetAllByCompanyIdAsync(company.Id); // get schedule of current company
                foreach (var meeting in companySchedule)
                {
                    meeting.Date = await _dateDbRequest.GetDateById(meeting.DateId);
                    schedule.Add(meeting); // add meeting to main schedule
                }
            }
            return View(schedule); // send them to view
        }

        public async Task<IActionResult> Create()
        {
            var createScheduleViewModel = new CreateScheduleViewModel();
            if (_signInManager.IsSignedIn(User))
            {
                return View(createScheduleViewModel);
            }
            return RedirectToAction("Index", "Company");
        }

        // get post request
        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleViewModel createScheduleViewModel)
        {
            if (ModelState.IsValid) // model validation
            {
                string companyCreatorId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                IEnumerable<Company> companies = await _companyDbRequest.GetByAppUserIdAsync(companyCreatorId); // get company list of current user
                var compamyId = companies.Last().Id;
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
                    CompanyId = compamyId
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
