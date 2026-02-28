using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services
{
    public class TaskItemService : ITaskItemService
    {
        private List<TaskItem> _taskItems = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Task 1", Description = "Description for Task 1", IsCompleted = false },
            new TaskItem { Id = 2, Title = "Task 2", Description = "Description for Task 2", IsCompleted = true },
            new TaskItem { Id = 3, Title = "Task 3", Description = "Description for Task 3", IsCompleted = false }
        };
        public List<TaskItem> GetAllTaskItems()
        {
            return _taskItems;
        }
         public TaskItem GetTaskItemById(int id)
        {
            return _taskItems.FirstOrDefault(t => t.Id == id);
        }
        public TaskItem CreateTaskItem(TaskItem taskItem)
        {
            taskItem.Id = _taskItems.Max(t=>t.Id)+1;
            _taskItems.Add(taskItem);
            return taskItem;
        }

        public TaskItem UpdateTaskItem(int Id, TaskItem taskItem)
        {
            var existingTaskItem = _taskItems.FirstOrDefault(t => t.Id == Id);
            if(existingTaskItem == null)
            {
                throw new Exception($"TaskItem with Id {Id} not found.");
            }
            existingTaskItem.Title = taskItem.Title;
            existingTaskItem.Description = taskItem.Description;
            existingTaskItem.IsCompleted = taskItem.IsCompleted;
            return existingTaskItem;
        }

        public void DeleteTaskItem(int id)
        {
            var taskItem = _taskItems.FirstOrDefault(t => t.Id == id);
            if (taskItem != null)
            {
                _taskItems.Remove(taskItem);
            }
            else
            {
                throw new Exception($"TaskItem with Id {id} not found.");
            }

        }

    }
}