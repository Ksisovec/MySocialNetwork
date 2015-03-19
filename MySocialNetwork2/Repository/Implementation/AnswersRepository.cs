using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Interfaces;

namespace MySocialNetwork2.Repository.Implementation
{
    public class AnswersRepository : RepositoryBase<Answers>, IAnswersRepository
    {
        public AnswersRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}