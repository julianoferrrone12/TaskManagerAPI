using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Dtos.Item;
using TaskManagerAPI.Helpers;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Mappers;

namespace TaskManagerAPI.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly TaskManagerContext _context;
        private readonly ITaskItemRepository _itemRepo;
        public TaskItemController(TaskManagerContext context, ITaskItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var items = await _itemRepo.GetAllAsync(query);

            var itemDto = items.Select(s => s.ToItemDto());

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = await _itemRepo.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.ToItemDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemRequestDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemModel = itemDto.ToItemFromCreateDTO();
            await _itemRepo.CreateAsync(itemModel);
            return CreatedAtAction(nameof(GetById), new { id = itemModel.Id }, itemModel.ToItemDto());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateItemRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemModel = await _itemRepo.UpdateAsync(id, updateDto);
            if (itemModel == null)
            {
                return NotFound();
            }

            return Ok(itemModel.ToItemDto());
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemModel = await _itemRepo.DeleteAsync(id);

            if (itemModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}