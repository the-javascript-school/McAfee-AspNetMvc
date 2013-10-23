using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TodosController : Controller
    {
        //
        // GET: /Todos/
        public TodosController()
        {
            if (TodoRepository.Todos.Count() == 0) {
                TodoRepository.Add("Test Item - 1");
                TodoRepository.Add("Test Item - 2");
                TodoRepository.Add("Test Item - 3");
                TodoRepository.Add("Test Item - 4");
            }
        }

        public ActionResult Index()
        {
            return View(TodoRepository.Todos);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View(new Todo());
        }

        [HttpPost]
        public ActionResult AddNew(Todo todo) {
            if (string.IsNullOrEmpty(todo.Description) || todo.Description.Length < 10) {
                this.ModelState.AddModelError("Description", "Description is too short!!");
                return View(todo);
            }
            TodoRepository.Add(todo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var itemToEdit = TodoRepository.Todos.First(t => t.Id == id);
            return View(itemToEdit);
        }

    }
}
