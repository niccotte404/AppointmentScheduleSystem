using AppointmentScheduleSystem.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace AppointmentScheduleSystem.Helpers
{
    public class CloudinaryRequest : ICloudinaryRequest
    {
        private readonly Cloudinary _cloudinary; // get object
        public CloudinaryRequest(IOptions<CloudinaryAccount> cloudinaryAccountOptions)
        {
            // get data from appsettings.json to new Account
            Account account = new Account(
                cloudinaryAccountOptions.Value.Account,
                cloudinaryAccountOptions.Value.ApiKey,
                cloudinaryAccountOptions.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(account); // make new cloudinary object with account data
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile imageFile)
        {
            var uploadResult = new ImageUploadResult(); // create response of upload image object 

            if (imageFile.Length > 0) // check file
            {
                using var stream = imageFile.OpenReadStream(); // read image
                var uploadParans = new ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, stream), // set file description
                    Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face") // set cloudinary upload transform params
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParans); // send image to cloudinary
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicImageId)
        {
            var deletionParams = new DeletionParams(publicImageId); // create response to cloudinary to delete image
            var deletionResut = await _cloudinary.DestroyAsync(deletionParams); // delete image
            return deletionResut;
        }
    }
}
