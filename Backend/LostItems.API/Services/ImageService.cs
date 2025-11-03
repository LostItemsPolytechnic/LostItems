using LostItems.API.Interfaces.Repos;
using LostItems.API.Interfaces.Services;

namespace LostItems.API.Services
{
    public class ImageService : IImageService
    {
        private int _counter = 0;
        private readonly IItemRepo _itemRepo;

        public ImageService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }


        public byte[] GetImage(string imageUrl)
        {
            _itemRepo.SaveChanges();
        }

        public string UploadImage(byte[] imageData, string fileName)
        {
            
        }
    }
}
