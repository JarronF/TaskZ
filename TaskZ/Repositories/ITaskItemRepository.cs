using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Repositories
{
    public interface ITaskItemRepository
    {
        public IEnumerable GetTaskItems();
        public Task<List<TaskItem>> GetTasksByParentId(int? parentId);
        public Task<TaskItem> GetTaskItemById(int taskId);
        public Task<bool> DeleteTaskItem(int taskId);
        public void UpdateTaskItem(TaskItem taskItem);      
        public void CreateTaskItem(TaskItem taskItem);
        public int Save();
    }
}
