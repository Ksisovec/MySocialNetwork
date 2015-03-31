using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Implementation;

namespace MySocialNetwork2.ViewModels
{
    public class CreateTaskViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        //public IEnumerable<string> Tags { get; set; }
        public string Answers { get; set; }
        public string Tag { get; set; }






        private readonly List<Category> _categories =
            new CategoryRepository(new ApplicationDbContext()).Get().ToList();

        [Display(Name = "Category")]
        public int SelectCategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories
        {
            get { return new SelectList(_categories, "ID", "CategoryName"); }
        }
    

    }
}