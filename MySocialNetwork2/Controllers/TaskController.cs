using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MySocialNetwork2.Models;
using MySocialNetwork2.Repository.Interfaces;
using MySocialNetwork2.ViewModels;

namespace MySocialNetwork2.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository taskRepository;
        private readonly ICategoryRepository categoryRepositoryitory;
        private readonly IAnswersRepository answersRepository;
        private readonly ITagRepository tagRepository;
        private ApplicationUserManager userManager;


        public TaskController()
        {

        }

        public TaskController(ITaskRepository repository, 
            ICategoryRepository categoryRepositoryitory,
            IAnswersRepository answersRepository)
        {
            this.taskRepository = repository;
            this.categoryRepositoryitory = categoryRepositoryitory;
            this.answersRepository = answersRepository;
        }


        public ApplicationUserManager UserManager
        {
            get { return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { userManager = value; }
        }


        [HttpGet]
        public ActionResult CreateTaskResult()
        {
            return View(new CreateTaskViewModel());
        }

        [HttpPost]
        public ActionResult CreateTaskResult(CreateTaskViewModel model)
        {
            if (model.Name == null || model.Name == "" || model.Content == null || model.Content == "")
                RedirectToAction("Index", "Home");
            //model.Author = User.Identity.Name;
        
            var taskmodel = new Task();
            //{
            taskmodel.NameOfTask = model.Name;
            taskmodel.ContentOfTask = model.Content;
            var category = categoryRepositoryitory.FindByID(model.SelectCategoryId);//.GetEnumerator().Current;
            taskmodel.CategoryId = category.ID;
            taskmodel.CategoryName = category.CategoryName;
            taskmodel.UserCreated = User.Identity.Name;
            taskmodel.Likes = 0;
            taskmodel.Dislikes = 0;
            taskmodel.RatingOfTask = 0;
            taskmodel.Locked = false;
            taskmodel.UserCreated = User.Identity.Name;
            taskRepository.Insert(taskmodel);
            if (model.Answers != null)
            {
                ICollection<Answers> answers = new Collection<Answers>();
                string[] ansStr = model.Answers.Split('\n');
                foreach (String ans in ansStr)
                {
                    Answers answer = new Answers();
                    answer.ContentOfAnswer = ans;   
                    answer.TaskID = taskmodel.ID;
                    answersRepository.Insert(answer);
                    answers.Add(answer);
                    
                }
                taskmodel.Answers = answers;
            }
            //if (model.Answers != null)
            //{
            //    ICollection<Tag> tags = new Collection<Tag>();
            //    string[] tagsStr = model.Tags.Split('#');
            //    foreach (string tag1 in tagsStr)
            //    {
            //        //if(tag1 != tagRepository.FindByID())
            //        //Tag tag = new Tag();
            //        //tag.TagId = tag1;
                    
            //    }
            //}




            //tagRepository.Insert(tags);
            taskRepository.Update(taskmodel);
            return RedirectToAction("ViewResult", "Task");
        }

        [HttpGet]
        public ActionResult ViewResult()
        {
            return View(taskRepository.Get());
        }

        [HttpPost]
        public ActionResult ViewResult(string url)
        {
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Index()
        {
            return View();
        }
    }
}