using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.Models;

namespace ToDoManager.Service
{
    public interface ITaskService
    {
        void CreateTaskList(CreateUpdateTaskListModel taskListModel);
        void UpdateTaskList(CreateUpdateTaskListModel taskListModel);
        List<TaskListModel> GetTaskList(int userId);
        void CreateTask(CreateUpdateTaskModel taskModel);
        void UpdateTask(CreateUpdateTaskModel taskModel);
        List<TaskModel> GetTasks(int taskListId);
    }
}
