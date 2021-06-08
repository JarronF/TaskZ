using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskZ.Data;
using TaskZ.Models;
using TaskZ.Services;

namespace TaskZ.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {        
        private readonly ITaskItemService _taskItemService;
        public List<TaskItem> HighLevelTaskList { get; set; } = new List<TaskItem>();
        public List<TaskItem> SubTaskList { get; set; } = new List<TaskItem>();
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger, ITaskItemService taskItemService)
        {     
            _logger = logger;
            _taskItemService = taskItemService;
        }
        public async Task OnGetAsync()
        {
            HighLevelTaskList = await _taskItemService.GetHighLevelTasks();
        }

        public async Task<PartialViewResult> OnGetSubTasksPartialAsync(int taskId)
        {
            SubTaskList = await _taskItemService.GetSubTasks(taskId);
            return Partial("_TaskListPartial", SubTaskList);
        }

        public async Task<ActionResult> OnGetDelete(int? id)
        {
            if (id != null)
            {
                await _taskItemService.DeleteTaskItem((int)id);
            }
            return RedirectToPage("Index");
        }
    }
}
