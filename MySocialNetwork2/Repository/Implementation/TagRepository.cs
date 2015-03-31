using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Interfaces;

namespace MySocialNetwork2.Repository.Implementation
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        //public string FindByContent(string tagName)
        //{

        //    return context.Set<string>().ToString();
        //}

    }
}