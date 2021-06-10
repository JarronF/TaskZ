using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Data;
using TaskZ.Models;
using TaskZ.Repositories;

namespace TaskZ.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskRepo;
        public TaskItemService(ITaskItemRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public async Task<List<TaskItem>> GetHighLevelTasks() => await _taskRepo.GetTasksByParentId(null);
        public async Task<List<TaskItem>> GetSubTasks(int parentId) => await _taskRepo.GetTasksByParentId(parentId);
        public async Task<TaskItem> GetTaskItemById(int taskId) => await _taskRepo.GetTaskItemById(taskId);
        public async Task<int> CreateTaskItem(TaskItem taskItem)
        {
            await _taskRepo.CreateTaskItem(taskItem);
            return await _taskRepo.SaveAsync();
        }

        public async Task<bool> DeleteTaskItem(int taskId) => await _taskRepo.DeleteTaskItem(taskId);

        public async Task UpdateTaskItem(TaskItem taskItem) => await _taskRepo.UpdateTaskItem(taskItem);
    }
}
