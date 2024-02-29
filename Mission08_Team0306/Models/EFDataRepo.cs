
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

        public List<Task> Tasks => _context.Tasks.ToList();

        public Task GetTaskById(int id) 
        {
            return _context.Tasks.Single(x => x.TaskId == id);
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
