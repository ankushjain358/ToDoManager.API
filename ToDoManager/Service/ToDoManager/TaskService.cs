using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.DataModel;
using ToDoManager.Models;
using ToDoManager.Repository;

namespace ToDoManager.Service
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public TaskService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void CreateTask(CreateUpdateTaskModel taskModel)
        {
            var taskToCreate = _mapper.Map<Tasks>(taskModel);
            _unitOfWork.TaskRepository.Insert(taskToCreate);
            _unitOfWork.SaveChanges();
        }

        public void CreateTaskList(CreateUpdateTaskListModel taskListModel)
        {
            var taskListToCreate = _mapper.Map<TaskLists>(taskListModel);
            _unitOfWork.TaskListRepository.Insert(taskListToCreate);
            _unitOfWork.SaveChanges();
        }

        public List<TaskListModel> GetTaskList(int userId)
        {
            var tasklists = _unitOfWork.TaskListRepository.Get(tasklist => tasklist.UserId == userId);
            return _mapper.Map<List<TaskListModel>>(tasklists);
        }

        public List<TaskModel> GetTasks(int taskListId)
        {
            var tasks = _unitOfWork.TaskRepository.Get(task => task.TaskListId == taskListId);
            return _mapper.Map<List<TaskModel>>(tasks);
        }

        public void UpdateTask(CreateUpdateTaskModel taskModel)
        {
            var taskToUpdate = _mapper.Map<Tasks>(taskModel);
            _unitOfWork.TaskRepository.Update(taskToUpdate);
            _unitOfWork.SaveChanges();
        }

        public void UpdateTaskList(CreateUpdateTaskListModel taskListModel)
        {
            var taskListToUpdate = _mapper.Map<TaskLists>(taskListModel);
            _unitOfWork.TaskListRepository.Update(taskListToUpdate);
            _unitOfWork.SaveChanges();
        }
    }
}
