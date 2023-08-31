using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;
        public CompanyController(AppDbContext context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel createCompanyViewModel)
        {
            return View();
        }
    }
}
