using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySocialNetwork2.Models
{
    public class Tag
    {
        
        public int ID { get; set; }
        public string ContentOfTag { get; set; }
        public int RatingOfTag { get; set; }
        public virtual ICollection<Task> Task { get; set; } 
    }
}