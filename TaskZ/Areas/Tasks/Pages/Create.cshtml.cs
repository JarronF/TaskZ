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

namespace TaskZ.Areas.Tasks.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList UsersDropDownList { get; set; }
        public string SelectedUserId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Title { get; set; }
            [Display(Name = "Description")]
            public string ShortDescription { get; set; }
            [Display(Name = "Due Date")]
            public DateTime DueDate { get; set; }
            public int TimeSpent { get; set; }
            public int TimeEstimated { get; set; }
            [Display(Name = "Assigned User")]
            public int SelectedUserID { get; set; }
        }

        public void OnGet()
        {            
            UsersDropDownList = Utilities.UserUtils.PopulateUsersDropDownList(_context, User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"));
        }

        public void PopulateUsersDropDownList(ApplicationDbContext _context,
            string selectedUserID = null)
        {
            var userQuery = from u in _context.Users
                            orderby u.FirstName // Sort by name.
                            select u;

            UsersDropDownList = new SelectList(userQuery, "Id", "UserName", selectedUserID);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var taskItem = new TaskItem
            {
                Title = Input.Title,
                DueDate = Input.DueDate,
                ShortDescription = Input.ShortDescription,
                AssignedUserId = Input.SelectedUserID
            };

            _context.Add(taskItem);
            _context.SaveChanges();
            return RedirectToPage("Areas/DashBoard");
        }
    }
}

