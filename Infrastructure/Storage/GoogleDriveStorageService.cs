using Domain.Entities;
using Domain.Storage;
using Google.Apis.Drive.v3;

namespace Infrastructure.Storage
{
    public class GoogleDriveStorageService<T> : IStorageService<T>
    {
        public string Upload(IFormFile file, User<T> user)
        {
            throw new NotImplementedException();

            var service = new DriveService();
            // Implementação do método Upload

            var driveFile = new Google.Apis.Drive.v3.Data.File
            {
                Name = file.Name,
                MimeType = file.ContentType,
            };

            var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
            command.Fields = "id";
            var response = command.Upload();

            if (response.Status is not Google.Apis.Upload.UploadStatus.Completed or Google.Apis.Upload.UploadStatus.NotStarted)
                throw new Exception();

            // return command.ResponseBody.Id;
            return "Simulando upload realizado";
        }
    }
}
