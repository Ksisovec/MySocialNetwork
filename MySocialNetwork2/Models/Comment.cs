using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySocialNetwork2.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string TextOfComment { get; set; }
        public string UserID { get; set; }
        public int TaskID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Task Task { get; set; }
    }
}