using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Dtos.Item;
using TaskManagerAPI.Helpers;
using TaskManagerAPI.Models;


namespace TaskManagerAPI.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllAsync(QueryObject query);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> CreateAsync(TaskItem itemModel);
        Task<TaskItem?> UpdateAsync(int id, UpdateItemRequestDto itemDto);
        Task<TaskItem?> DeleteAsync(int id);
    }
}