using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Services
{
    public interface ITaskItemService
    {
        Task<List<TaskItem>> GetHighLevelTasks();

        Task<List<TaskItem>> GetSubTasks(int parentId);
    }
}
