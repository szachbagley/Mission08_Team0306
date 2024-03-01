
using SQLitePCL;

namespace Mission08_Team0306.Models
{
    public class EFDataRepo : IDataRepo
    {

        private DataContext _context;
        public EFDataRepo(DataContext temp) 
        { 
            _context = temp;
        }

        public List<TaskViewModel> Tasks => _context.Tasks.ToList();

        public TaskViewModel GetTaskById(int id) 
        {
            return _context.Tasks.Single(x => x.TaskId == id);
        }

        public void AddTask(TaskViewModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(TaskViewModel task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskViewModel task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void CompleteTask(TaskViewModel Task)
        {
            var taskToComplete = _context.Tasks.Single(x => x.TaskId == Task.TaskId);
            taskToComplete.Completed = true;
            _context.SaveChanges();
        }
    }
}
