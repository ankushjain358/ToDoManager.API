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

        public void UpdateTask(CreateUpdateTaskModel taskModel)
        {
            var taskToUpdate = _mapper.Map<Tasks>(taskModel);
            _unitOfWork.TaskRepository.Update(taskToUpdate);
            _unitOfWork.SaveChanges();
        }
    }
}
