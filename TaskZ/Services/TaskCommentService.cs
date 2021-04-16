using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;
using TaskZ.Repositories;

namespace TaskZ.Services
{
    public class TaskCommentService: ITaskCommentService
    {
        private readonly ITaskCommentRepository _commentRepo;
        public TaskCommentService(ITaskCommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public int CreateComment(TaskComment comment)
        {
            _commentRepo.CreateComment(comment);
            return _commentRepo.Save();
        }
    }
}
