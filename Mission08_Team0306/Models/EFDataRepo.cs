
using SQLitePCL;

namespace Mission08_Team0306.Models
{
    public class EFDataRepo : IDataRepo
    {

        private DataBaseContext _context;
        public EFDataRepo(DataBaseContext temp) 
        { 
            _context = temp;
        }







        public List<Task> Tasks => _context.Tasks.ToList();
    }
}
