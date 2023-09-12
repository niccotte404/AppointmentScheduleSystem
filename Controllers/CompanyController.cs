using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICloudinaryRequest _cloudinaryRequest; // cloudinary api
        private readonly ICompanyDbRequest _dbRequest; // 
        private readonly SignInManager<AppUser> _signInManager;
        public CompanyController(ICloudinaryRequest cloudinaryRequest, ICompanyDbRequest dbRequest, SignInManager<AppUser> signInManager) 
        { 
            _cloudinaryRequest = cloudinaryRequest; // make connection to cloudinary api
            _dbRequest = dbRequest; // make connection to database
            _signInManager = signInManager; // mace connection to database with identity frmwk
        }

        // main page
        public async Task<IActionResult> Index()
        {
            var companies = await _dbRequest.GetAllAsync(); // get all companies data
            return View(companies); // redirect it to view
        }

        // get request to create company page
        [HttpGet]
        public IActionResult Create()
        {
            var createCompanyViewModel = new CreateCompanyViewModel();
            // need to match here with user ------
            return View(createCompanyViewModel);
        }

        // post request to create company page
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel createCompanyViewModel)
        {
            if (ModelState.IsValid && _signInManager.IsSignedIn(User))
            {
                var resultImageUpload = await _cloudinaryRequest.UploadImageAsync(createCompanyViewModel.Image); // get response from cloudinary
                var company = new Company
                {
                    Name = createCompanyViewModel.Name,
                    Description = createCompanyViewModel.Description,
                    Phone = createCompanyViewModel.Phone,
                    Email = createCompanyViewModel.Email,
                    Image = resultImageUpload.Url.ToString()
                };
                // map data from view with main model
                _dbRequest.Add(company); // attach data to database
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Image upload error"); // image upload validation
            }
            return View(createCompanyViewModel);
        }
    }
}
