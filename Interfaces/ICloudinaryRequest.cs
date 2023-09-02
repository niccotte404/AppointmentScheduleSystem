using CloudinaryDotNet.Actions;

namespace AppointmentScheduleSystem.Interfaces
{
    public interface ICloudinaryRequest
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile imageFile);
        Task<DeletionResult> DeleteImageAsync(string publicImageId);
    }
}
