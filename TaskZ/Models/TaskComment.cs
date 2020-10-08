using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskZ.Models
{
    public class TaskComment
    {
        public int Id { get; set; }        
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }        
        public int ParentId { get; set; }
        public virtual TaskItem Parent { get; set; }
    }
}
