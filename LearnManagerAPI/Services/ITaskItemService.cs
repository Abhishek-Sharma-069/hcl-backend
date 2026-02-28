using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services
{
    public interface ITaskItemService
    {
        List<TaskItem> GetAllTaskItems();
        TaskItem GetTaskItemById(int id);
        TaskItem CreateTaskItem(TaskItem taskItem);
        TaskItem UpdateTaskItem(int id, TaskItem taskItem);
        void DeleteTaskItem(int id);
    }
}