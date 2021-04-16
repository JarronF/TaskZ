using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;
using TaskZ.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskZ.Repositories
{
    public class TaskCommentRepository: ITaskCommentRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskCommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void DeleteTaskComment(int taskId)
        {
            throw new NotImplementedException();
        }

        public TaskComment GetCommentById(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetTaskComments()
        {
            throw new NotImplementedException();
        }

        public void CreateComment(TaskComment taskComment)
        {
            _db.Add(taskComment);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public void UpdateTaskComment(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
