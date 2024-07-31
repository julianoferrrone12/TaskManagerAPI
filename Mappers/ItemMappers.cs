using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;
using TaskManagerAPI.Dtos.Item;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Mappers
{
    public static class ItemMappers
    {
        public static ItemDto ToItemDto(this TaskItem itemModel)
        {
            return new ItemDto
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                Description = itemModel.Description,
                Status = itemModel.Status,
            };
        }

        public static TaskItem ToItemFromCreateDTO(this CreateItemRequestDto itemDto)
        {
            return new TaskItem
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Status = itemDto.Status,
            };
        }
    }
}