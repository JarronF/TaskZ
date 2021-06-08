using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;
using TaskZ.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskZ.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteTaskItem(int taskId)
        {
            var data = (from tskItem in _db.TaskItem
                        where tskItem.Id == taskId
                        select tskItem).SingleOrDefault();

            _db.Remove(data);
            var saveCount = await _db.SaveChangesAsync();
            return  saveCount > 0;
        }

        public async Task<TaskItem> GetTaskItemById(int TaskId)
        {
            return await _db.TaskItem
                    .Include(c => c.Comments)
                    .Where(t => t.Id == TaskId)
                    .SingleOrDefaultAsync();

            //return await _db.TaskItem.FindAsync(TaskId);
        }

        public IEnumerable GetTaskItems()
        {
            throw new NotImplementedException();
        }
        public async Task<List<TaskItem>> GetTasksByParentId(int? ParentId)
        {
            List<TaskItem> list = new List<TaskItem>();
            list = await _db.TaskItem
                .Where(tskItem => tskItem.ParentID == ParentId).ToListAsync();
            //                .Include(tskItem => tskItem.Children).ToListAsync();
            return list;
        }

        public void CreateTaskItem(TaskItem taskItem)
        {
            _db.Add(taskItem);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            _db.Entry(taskItem).State = EntityState.Modified;
        }

       
    }
}
