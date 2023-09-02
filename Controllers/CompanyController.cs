using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Helpers;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICloudinaryRequest _cloudinaryRequest;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompanyController(ICloudinaryRequest cloudinaryRequest, IHttpContextAccessor httpContextAccessor) 
        { 
            _cloudinaryRequest = cloudinaryRequest;
            _httpContextAccessor = httpContextAccessor;
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
            if (ModelState.IsValid != false)
            {
                var resultImageUpload = await _cloudinaryRequest.UploadImageAsync(createCompanyViewModel.Image);
                var company = new CreateCompanyViewModel
                {
                    Name = createCompanyViewModel.Name,
                    Description = createCompanyViewModel.Description,
                    Phone = createCompanyViewModel.Phone,
                    Email = createCompanyViewModel.Email,
                    ImageUrl = resultImageUpload.Url.ToString()
                };
                
            }
            else
            {
                ModelState.AddModelError("", "Image upload error");
            }
            return View(createCompanyViewModel);
        }
    }
}
