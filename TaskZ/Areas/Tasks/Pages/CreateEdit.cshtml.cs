using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskZ.Models;
using TaskZ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TaskZ.Services;
using TaskZ.Repositories;

namespace TaskZ.Areas.Tasks.Pages
{
    public class CreateEditModel : PageModel
    {
        private readonly ITaskItemService _taskItemService;
        private readonly ITaskCommentService _commentService;

        private readonly IUserRepository _userRepo;
        public CreateEditModel(ITaskItemService taskItemService, ITaskCommentService commentService, IUserRepository userRepo)
        {
            _taskItemService = taskItemService;
            _commentService = commentService;
            _userRepo = userRepo;
        }
        [BindProperty]
        public int? TaskId { get; set; }
        private string PageMode
        {
            get
            {
                return TaskId == null ? "Create" : "Edit";
            }
        }
        public SelectList UsersDropDownList { get; set; }
        public string SelectedUserId { get; set; }
        public List<TaskComment> Comments { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Title { get; set; }
            [Display(Name = "Description")]
            [Required]
            public string ShortDescription { get; set; }
            [
                Required,
                DataType(DataType.Date),
                Display(Name = "Due Date")
            ]
            public DateTime DueDate { get; set; }
            public int TimeSpent { get; set; }
            public int TimeEstimated { get; set; }
            [Display(Name = "Assigned User")]
            public int SelectedUserID { get; set; }
            public string Comment { get; set; }
        }

        public async Task OnGet(int? id)
        {
            UsersDropDownList = new SelectList(_userRepo.GetAllUsers(), "Id", "UserName", User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"));
            TaskId = id;

            if (PageMode == "Edit") await LoadPage((int)TaskId);
        }
        private async Task LoadPage(int id)
        {
            var data = await _taskItemService.GetTaskItemById(id);
            Input = new InputModel
            {
                Title = data.Title,
                DueDate = data.DueDate,
                ShortDescription = data.ShortDescription,
                SelectedUserID = (int)data.AssignedUserId
            };
            Comments = new List<TaskComment>(data.Comments);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (PageMode == "Edit")
            {
                await UpdateTask(Input, (int)TaskId);
            }
            else
            {
                if (Input.Comment.Length > 0)
                {
                    _commentService.CreateComment(CreateComment(Input));
                }
                else
                {
                    await _taskItemService.CreateTaskItem(CreateTask(Input));
                }
            }
            //_taskItemRepo.Save();
            return RedirectToPage("Pages");
        }
        private async Task UpdateTask(InputModel input, int taskId)
        {
            await _taskItemService.UpdateTaskItem(CreateTask(input, taskId));
        }
        private TaskComment CreateComment(InputModel input)
        {
            var comment = new TaskComment();
            if (TaskId == null)
            {
                TaskItem tsk = CreateTask(input);
                comment.Parent = tsk;
            }
            else
            {
                comment.ParentId = (int)TaskId;
            }
            comment.Comment = input.Comment;
            comment.CommentDate = DateTime.Now;
            comment.UserId = input.SelectedUserID;
            return comment;
        }
        private TaskItem CreateTask(InputModel input, int taskId = 0)
        {
            return new TaskItem
            {
                Id = taskId,
                Title = input.Title,
                DueDate = input.DueDate,
                ShortDescription = input.ShortDescription,
                AssignedUserId = input.SelectedUserID
            };
        }
    }
}
