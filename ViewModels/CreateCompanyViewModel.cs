namespace AppointmentScheduleSystem.ViewModels
{
    public class CreateCompanyViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }    
    }
}
