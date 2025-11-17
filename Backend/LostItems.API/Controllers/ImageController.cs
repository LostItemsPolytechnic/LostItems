using LostItems.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LostItems.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("upload")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadImage([FromForm] IFormFileCollection files) 
        {
            var file = files.FirstOrDefault(); 

            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected or is empty.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                
                try
                {
                    string imageUrl = _imageService.UploadImage(fileBytes, file.FileName);
                    return Ok(new { imageUrl = imageUrl });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
    }
}