using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Helpers;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICloudinaryRequest _cloudinaryRequest;
        private readonly ICompanyDbRequest _dbRequest;
        public CompanyController(ICloudinaryRequest cloudinaryRequest, ICompanyDbRequest dbRequest) 
        { 
            _cloudinaryRequest = cloudinaryRequest;
            _dbRequest = dbRequest;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var companies = await _dbRequest.GetAllAsync();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createCompanyViewModel = new CreateCompanyViewModel();
            return View(createCompanyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel createCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                var resultImageUpload = await _cloudinaryRequest.UploadImageAsync(createCompanyViewModel.Image);
                var company = new Company
                {
                    Name = createCompanyViewModel.Name,
                    Description = createCompanyViewModel.Description,
                    Phone = createCompanyViewModel.Phone,
                    Email = createCompanyViewModel.Email,
                    Image = resultImageUpload.Url.ToString()
                };
                _dbRequest.Add(company);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Image upload error");
            }
            return View(createCompanyViewModel);
        }
    }
}
