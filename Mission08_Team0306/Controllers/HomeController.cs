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

        //Adds a task through EFDataRepo.cs
        [HttpPost]
        public IActionResult TasksView(TaskViewModel task)
        {
            _repo.AddTask(task);
            return RedirectToAction("QuadrantView");
        }

        //Loads qudrants with tasks that are not completed
        public IActionResult QuadrantView()
        {
            var ToDo = _repo.Tasks
                .Where(x => x.Completed == false)
                .OrderBy(x => x.DueDate) //ordered by due date
                .ToList();

            return View(ToDo);
        }


        //retrieves tasks by ID number and loads them in the editor
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var taskToEdit = _repo.GetTaskById(id);

            return View("TasksView", taskToEdit);
        }

        //loads the editor with desired task
        [HttpPost]
        public IActionResult Edit(TaskViewModel task)
        {
            _repo.UpdateTask(task);
            return RedirectToAction("QuadrantView");
        }

        //sends task to Delete view for confrimation
        [HttpGet] 
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.GetTaskById(id);
            return View(taskToDelete);
        }

        //deletes task after confirmed deletion
        [HttpPost]
        public IActionResult Delete(TaskViewModel task)
        {
            _repo.DeleteTask(task);

            return RedirectToAction("QuadrantView");
        }

        //Marks a task as complete and sends user back to quadrant page
        [HttpGet]
        public IActionResult Complete(int id)
        {
            var taskToComplete = _repo.GetTaskById(id);

            _repo.CompleteTask(taskToComplete);

            return RedirectToAction("QuadrantView");
        }
    }
}
