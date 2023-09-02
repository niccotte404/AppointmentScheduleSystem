using AppointmentScheduleSystem.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace AppointmentScheduleSystem.Helpers
{
    public class CloudinaryRequest : ICloudinaryRequest
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryRequest(IOptions<CloudinaryAccount> cloudinaryAccountOptions)
        {
            Account account = new Account(
                cloudinaryAccountOptions.Value.Account,
                cloudinaryAccountOptions.Value.ApiKey,
                cloudinaryAccountOptions.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile imageFile)
        {
            var uploadResult = new ImageUploadResult();

            if (imageFile.Length > 0)
            {
                using var stream = imageFile.OpenReadStream();
                var uploadParans = new ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, stream),
                    Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParans);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicImageId)
        {
            var deletionParams = new DeletionParams(publicImageId);
            var deletionResut = await _cloudinary.DestroyAsync(deletionParams);
            return deletionResut;
        }
    }
}
