using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySocialNetwork2.Models
{
    public class Answers
    {
        public int ID { set; get; }
        public string ContentOfAnswer { get; set; }
        public int TaskID { get; set; }
        public virtual Task Task { get; set; }
    }
}