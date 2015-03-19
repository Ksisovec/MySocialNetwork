using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Interfaces;

namespace MySocialNetwork2.Repository.Implementation
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public void AddLike(Task model)
        {
            model.Likes++;
            context.SaveChanges();
        }

        public void AddDislike(Task model)
        {
            model.Dislikes++;
            context.SaveChanges();
        }
    }
}