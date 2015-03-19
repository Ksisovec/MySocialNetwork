using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Interfaces;

namespace MySocialNetwork2.Repository.Implementation
{
    public class ReferenceToTaskRepository : RepositoryBase<ReferenceToTask>, IReferenceToTaskRepository
    {
        public ReferenceToTaskRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

    }
}