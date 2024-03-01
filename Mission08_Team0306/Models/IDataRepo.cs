namespace Mission08_Team0306.Models
{
    public interface IDataRepo
    {
        List<Tasks> Tasks { get; }

        public Tasks GetTaskById(int id);

        public void AddTask(Tasks task);

        public void DeleteTask(Tasks task);

        public void UpdateTask(Tasks task);

    }
}
