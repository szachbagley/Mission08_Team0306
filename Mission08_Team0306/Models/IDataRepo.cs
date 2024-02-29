namespace Mission08_Team0306.Models
{
    public interface IDataRepo
    {
        List<Task> Tasks { get; }

        public Task GetTaskById(int id);

        public void AddTask(Task task);

        public void DeleteTask(Task task);

        public void UpdateTask(Task task);

    }
}
