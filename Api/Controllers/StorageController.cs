using Application.UseCases.Users.UploadProfilePhoto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly UploadProfilePhotoUseCase<IFormFile> _uploadProfilePhotoUseCase;

        public StorageController(UploadProfilePhotoUseCase<IFormFile> uploadProfilePhotoUseCase)
        {
            _uploadProfilePhotoUseCase = uploadProfilePhotoUseCase;
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile file)
        {
            _uploadProfilePhotoUseCase.Execute(file);
            return Ok("Upload realizado");
        }
    }
}