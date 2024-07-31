using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Dtos.Item;
using TaskManagerAPI.Helpers;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repository
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TaskManagerContext _context;
        public TaskItemRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateAsync(TaskItem itemModel)
        {
            await _context.TaskItem.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<TaskItem?> DeleteAsync(int id)
        {
            var itemModel = await _context.TaskItem.FirstOrDefaultAsync(x => x.Id == id);

            if (itemModel == null)
            {
                return null;
            }

            _context.TaskItem.Remove(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<List<TaskItem>> GetAllAsync(QueryObject query)
        {
            var items = _context.TaskItem.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                items = items.Where(s => EF.Functions.ILike(s.Name, $"%{query.Name}%"));
            }
            if (!string.IsNullOrWhiteSpace(query.Status))
            {
                var normalizedStatus = query.Status.Trim();

                if (Enum.TryParse<TaskSituation>(normalizedStatus, true, out var statusEnum))
                {
                    items = items.Where(s => s.Status == statusEnum);
                }
            }
            if (string.IsNullOrWhiteSpace(query.SortBy) || query.SortBy.Equals("CreatedDate", StringComparison.OrdinalIgnoreCase))
            {
                items = query.IsDescending ? items.OrderByDescending(s => s.CreatedDate) : items.OrderBy(s => s.CreatedDate);
            }
            else if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                items = query.IsDescending ? items.OrderByDescending(s => s.Name) : items.OrderBy(s => s.Name);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await items.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItem.FindAsync(id);
        }

        public async Task<TaskItem?> UpdateAsync(int id, UpdateItemRequestDto itemDto)
        {
            var existingItem = await _context.TaskItem.FirstOrDefaultAsync(x => x.Id == id);

            if (existingItem == null)
            {
                return null;
            }

            existingItem.Name = itemDto.Name;
            existingItem.Description = itemDto.Description;
            existingItem.Status = itemDto.Status;

            await _context.SaveChangesAsync();

            return existingItem;
        }
    }
}