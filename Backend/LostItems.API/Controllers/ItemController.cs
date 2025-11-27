using System;
using System.Threading.Tasks;
using LostItems.API.DTOs;
using LostItems.API.Models;
using LostItems.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LostItems.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddItemDto dto, [FromQuery] Guid? founderId = null)
        {
            if (dto == null) return BadRequest();

            if (!founderId.HasValue)
                return BadRequest(new { message = "FounderId is required (pass ?founderId=...)" });

            var created = await _itemService.CreateAsync(dto, founderId.Value);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AddItemDto dto)
        {
            var updated = await _itemService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _itemService.DeleteAsync(id);
            if (!ok) return NotFound();
            return Ok(new { message = "Deleted" });
        }

        [HttpPost("return/{id}")]
        public async Task<IActionResult> MarkReturned(Guid id)
        {
            var ok = await _itemService.MarkReturnedAsync(id);
            if (!ok) return NotFound();
            return Ok(new { message = "Marked returned" });
        }
    }
}
