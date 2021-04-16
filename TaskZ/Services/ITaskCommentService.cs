using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Services
{
    public interface ITaskCommentService
    {
        public int CreateComment(TaskComment comment);     
    }
}
