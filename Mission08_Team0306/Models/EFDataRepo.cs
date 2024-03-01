
using SQLitePCL;

// This is the repository where I link all of the data so I can edit this directly.

namespace Mission08_Team0306.Models
{
    // A public class for the repo 
    public class EFDataRepo : IDataRepo
    {

        private DataContext _context;
        public EFDataRepo(DataContext temp) 
        { 
            _context = temp;
        }
        // To grab all of the data 
        public List<TaskViewModel> Tasks => _context.Tasks.ToList();

        public TaskViewModel GetTaskById(int id) 
        {
            return _context.Tasks.Single(x => x.TaskId == id);
        }
        // One to add a task
        public void AddTask(TaskViewModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        // Delete Task
        public void DeleteTask(TaskViewModel task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        // Update task

        public void UpdateTask(TaskViewModel task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        // Complete Task
        public void CompleteTask(TaskViewModel Task)
        {
            var taskToComplete = _context.Tasks.Single(x => x.TaskId == Task.TaskId);
            taskToComplete.Completed = true;
            _context.SaveChanges();
        }
    }
}
