using LostItems.API.DTOs;
using LostItems.API.Entities;
using LostItems.API.Interfaces.Repos;
using LostItems.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LostItems.API.Controllers
{
    [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase
    {
        // https://lostItems.com/item/add
        private readonly IItemRepo _itemRepo;
        private readonly IImageService _imageService;

        public ItemController(IItemRepo itemRepo, IImageService imageService)
        {
            _itemRepo = itemRepo;
            _imageService = imageService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItem([FromBody] AddItemDto itemDto, [FromBody] string image)
        {
            try
            {
                var imageUrl = await _imageService.UploadImage(Convert.FromBase64String(image));

                var item = new Item(itemDto.Name, itemDto.Description, imageUrl);

                await _itemRepo.AddItemAsync(item);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await _itemRepo.GetItemsAsync();

                var itemDtos = items.Select(item => new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImgUrl = item.ImgUrl
                }).ToList();

                return Ok(itemDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetItemById([FromBody] Guid id)
        {
            try
            {
                var item = await _itemRepo.GetItemByIdAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                var itemDto = new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImgUrl = item.ImgUrl
                };

                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateItem([FromBody] ItemDto itemDto)
        {
            try
            {
                var item = new Item(itemDto.Name, itemDto.Description, itemDto.ImgUrl)
                {
                    Id = itemDto.Id
                };

                var result = await _itemRepo.Update(item);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteItem([FromBody] Guid id)
        {
            try
            {
                var result = _itemRepo.DeleteItem(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
