using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySocialNetwork2.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string NameOfTask { get; set; }
        public int RatingOfTask { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string ContentOfTask { get; set; }
        public bool Locked { get; set; }
        public string UserCreated { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ApplicationUser> User { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<ReferenceToTask> Reference { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<SolvedTask> SolvedTask { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}