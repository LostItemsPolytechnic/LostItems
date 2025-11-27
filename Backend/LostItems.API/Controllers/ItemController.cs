using LostItems.API.DTOs;
using LostItems.API.Enums;
using LostItems.API.Interfaces.Repositories;
using LostItems.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostItems.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepo;
        private readonly IReturnedItemRepository _returnedItemRepo;

        public ItemController(IItemRepository itemService, IReturnedItemRepository returnedItemRepo)
        {
            _itemRepo = itemService;
            _returnedItemRepo = returnedItemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _itemRepo.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _itemRepo.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddItemDto dto)
        {
            if (dto == null) return BadRequest();

            await _itemRepo.AddAsync(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ItemDto dto)
        {
            var updated = await _itemRepo.UpdateAsync(dto);
            if (updated == false) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _itemRepo.DeleteByIdAsync(id);
            if (!ok) return NotFound();
            return Ok(new { message = "Deleted" });
        }

        [HttpPost("return/{id}")]
        public async Task<IActionResult> MarkReturned(Guid id, [FromQuery] Guid loserId)
        {
            await _itemRepo.UpdateItemStatusAsync(id, ItemStatusEnum.Returned);
            await _returnedItemRepo.AddAsync(new ReturnedItem
            {
                ItemId = id,
                LoserId = loserId
            });

            return Ok(new { message = "Marked returned" });
        }
    }
}
