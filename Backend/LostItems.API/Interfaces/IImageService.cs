namespace LostItems.API.Interfaces
{
    public interface IImageService
    {
        string UploadImage(byte[] imageData, string fileName);
        byte[] GetImage(string imageUrl);
    }
}