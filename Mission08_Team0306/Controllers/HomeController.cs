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
            return View(new Models.TaskViewModel());
        }

        [HttpPost]
        public IActionResult TasksView(Models.TaskViewModel task)
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

            return View("Tasks", taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.TaskViewModel task)
        {
            _repo.UpdateTask(task);
            return RedirectToAction("QuadrantView");
        }

        [HttpGet] 
        IActionResult Delete(int id)
        {
            var taskToDelete = _repo.GetTaskById(id);
            return View(taskToDelete);
        }

        [HttpPost]
        IActionResult Delete(Models.TaskViewModel task)
        {
            _repo.DeleteTask(task);

            return RedirectToAction("QuadrantView");
        }




    }
}
