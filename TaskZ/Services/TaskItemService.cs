using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Data;
using TaskZ.Models;

namespace TaskZ.Services
{
    public class TaskItemService : ITaskItemService
    {
        private ApplicationDbContext _db;        
        public TaskItemService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<TaskItem>> GetHighLevelTasks()
        {
            List<TaskItem> list = new List<TaskItem>();
            list = await _db.TaskItem
                .Where(tskItem => tskItem.ParentID == null).ToListAsync();
                //.Include(tskItem => tskItem.Children).ToListAsync();

            return list;
        }
        public async Task<List<TaskItem>> GetSubTasks(int parentId)
        {
            List<TaskItem> list = new List<TaskItem>();
            list = await _db.TaskItem
                .Where(tskItem => tskItem.ParentID == parentId).ToListAsync();
//                .Include(tskItem => tskItem.Children).ToListAsync();
            return list;
        }
    }
}
