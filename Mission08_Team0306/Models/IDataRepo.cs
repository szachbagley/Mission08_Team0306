namespace Mission08_Team0306.Models
{
    // Finish connecting the repository
    public interface IDataRepo
    {
        List<TaskViewModel> Tasks { get; }

        public TaskViewModel GetTaskById(int id);

        public void AddTask(TaskViewModel task);

        public void DeleteTask(TaskViewModel task);

        public void UpdateTask(TaskViewModel task);

        public void CompleteTask(TaskViewModel task);

    }
}
