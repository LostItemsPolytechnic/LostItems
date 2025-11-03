namespace LostItems.API.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(byte[] imageData);
    }
}
