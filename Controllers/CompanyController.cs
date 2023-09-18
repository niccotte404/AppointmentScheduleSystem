using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppointmentScheduleSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICloudinaryRequest _cloudinaryRequest; // cloudinary api
        private readonly ICompanyDbRequest _dbRequest; // 
        private readonly SignInManager<AppUser> _signInManager;
        private readonly HttpContextAccessor _httpContextAccessor;
        public CompanyController(ICloudinaryRequest cloudinaryRequest, ICompanyDbRequest dbRequest, SignInManager<AppUser> signInManager, HttpContextAccessor httpContextAccessor) 
        { 
            _cloudinaryRequest = cloudinaryRequest; // make connection to cloudinary api
            _dbRequest = dbRequest; // make connection to database
            _signInManager = signInManager; // make connection to database with identity frmwk
            _httpContextAccessor = httpContextAccessor;
        }

        // main page
        public async Task<IActionResult> Index()
        {
            var companies = await _dbRequest.GetAllAsync(); // get all companies data
            return View(companies); // redirect it to view
        }


        public async Task<IActionResult> About(int id)
        {
            Company companies = await _dbRequest.GetByIdAsync(id);
            return View(companies);
        }
        

        // get request to create company page
        [HttpGet]
        public IActionResult Create()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var appUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var createCompanyViewModel = new CreateCompanyViewModel();
                createCompanyViewModel.CreatorId = appUserId;
                return View(createCompanyViewModel);
            }
            return View();
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
                    Image = resultImageUpload.Url.ToString(),
                    AppUserId = createCompanyViewModel.CreatorId
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


        public async Task<IActionResult> Match(int id)
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);
            currentUser.CompanyId = id;
            var updateResult = await _signInManager.UserManager.UpdateAsync(currentUser);
            return RedirectToAction("Index", "Home");
        }
    }
}
