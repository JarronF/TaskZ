using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Repositories
{
    public interface ITaskCommentRepository
    {
        public IEnumerable GetTaskComments();
        public void DeleteTaskComment(int taskId);
        public void UpdateTaskComment(TaskItem taskItem);
        public TaskComment GetCommentById(int commentId);
        public void CreateComment(TaskComment taskComment);
        public int Save();
    }
}
