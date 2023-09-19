namespace AppointmentScheduleSystem.ViewModels
{
    public class CreateCompanyViewModel
    {
        // set params that often used to match view and model (database)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? AppUserId { get; set; }
    }
}
