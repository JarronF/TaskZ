using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskZ.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int? ParentID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DueDate { get; set; }
        public int? TimeSpent { get; set; }
        public int? TimeEstimated { get; set; }
        public int? AssignedUserId { get; set; }
        public ApplicationUser AssignedUser { get; set; }
        public virtual TaskItem Parent { get; set; }
        public virtual ICollection<TaskItem> Children { get; set; }
        //public int? TaskCommentId { get; set; }
        //public virtual ICollection<TaskComment> Comments { get; set; }
    }
}
