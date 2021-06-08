using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Services
{
    public interface ITaskItemService
    {
        public Task<List<TaskItem>> GetHighLevelTasks();
        public Task<List<TaskItem>> GetSubTasks(int parentId);
        public Task<TaskItem> GetTaskItemById(int taskId);
        public int CreateTaskItem(TaskItem taskItem);
        public Task<bool> DeleteTaskItem(int TaskId);
    }
}
