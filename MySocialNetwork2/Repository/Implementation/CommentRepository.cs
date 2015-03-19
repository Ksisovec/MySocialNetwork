using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Interfaces;

namespace MySocialNetwork2.Repository.Implementation
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}