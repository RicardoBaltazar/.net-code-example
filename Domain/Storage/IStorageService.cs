using Domain.Entities;

namespace Domain.Storage
{
    public interface IStorageService<T>
    {
        string Upload(IFormFile file, User<T> user);
    }
}
