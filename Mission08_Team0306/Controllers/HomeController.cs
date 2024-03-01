using Microsoft.AspNetCore.Mvc;
using Mission08_Team0306.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Mission08_Team0306.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepo _repo;

        public HomeController(IDataRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TasksView()
        {
            return View(new TaskViewModel());
        }

        [HttpPost]
        public IActionResult TasksView(TaskViewModel task)
        {
            _repo.AddTask(task);
            return RedirectToAction("QuadrantView");
        }

        public IActionResult QuadrantView()
        {
            var ToDo = _repo.Tasks
                .Where(x => x.Completed == false)
                .OrderBy(x => x.DueDate)
                .ToList();

            return View(ToDo);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var taskToEdit = _repo.GetTaskById(id);

            return View("TasksView", taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TaskViewModel task)
        {
            _repo.UpdateTask(task);
            return RedirectToAction("QuadrantView");
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.GetTaskById(id);
            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel task)
        {
            _repo.DeleteTask(task);

            return RedirectToAction("QuadrantView");
        }

        [HttpGet]
        public IActionResult Complete(int id)
        {
            var taskToComplete = _repo.GetTaskById(id);

            _repo.CompleteTask(taskToComplete);

            return RedirectToAction("QuadrantView");
        }
    }
}
