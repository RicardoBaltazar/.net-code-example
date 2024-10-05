using Domain.Entities;
using Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;

namespace Application.UseCases.Users.UploadProfilePhoto
{
    public class UploadProfilePhotoUseCase<T>
    {
        private readonly IStorageService<T> _storageService;

        public UploadProfilePhotoUseCase(IStorageService<T> storageService)
        {
            _storageService = storageService;
        }

        public void Execute(IFormFile file)
        {
            var fileStream = file.OpenReadStream();

            // var isImage = FileTypeValidator.IsImage(fileStream);
            var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

            if (isImage == false)
            {
                throw new Exception("The file it not an image");
            }

            var user = GetFromDatabase();
            _storageService.Upload(file, user);
        }

        private User<T> GetFromDatabase()
        {
            return new User<T>
            {
                Id = 1,
                Name = "Ricardo",
                Email = "ricardo.baltazar04@gmail.com"
            };
        }
    }
}
