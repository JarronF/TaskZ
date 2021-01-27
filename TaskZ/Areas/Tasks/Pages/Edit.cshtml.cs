using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskZ.Models;
using TaskZ.Data;
using System.Security.Claims;

namespace TaskZ.Areas.Tasks.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public SelectList UsersDropDownList { get; set; }
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
            public int? SelectedUserID { get; set; }
        }

        public void OnGet(int? id)
        {
            UsersDropDownList = Utilities.UserUtils.PopulateUsersDropDownList(_db, User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"));
            if (id != null)
            {
                var data = (from tskItem in _db.TaskItem
                            where tskItem.Id == id
                            select tskItem).SingleOrDefault();

                Input = new InputModel
                {
                    Title = data.Title,
                    DueDate = data.DueDate,
                    ShortDescription = data.ShortDescription,
                    SelectedUserID = data.AssignedUserId
                };
            }
        }
    }
}

