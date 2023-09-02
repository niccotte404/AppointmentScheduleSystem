using CloudinaryDotNet.Actions;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface ICloudinaryRequest
    {
        public Task<ImageUploadResult> UploadImageAsync(IFormFile imageFile);
        public Task<DeletionResult> DeleteImageAsync(string publicImageId);
    }
}
