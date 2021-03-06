﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.Models;

namespace ToDoManager.Service
{
    public interface ITaskService
    {
        void CreateTask(CreateUpdateTaskModel taskModel);
        void UpdateTask(CreateUpdateTaskModel taskModel);
        void UpdateTitle(CreateUpdateTaskModel taskModel);
        void UpdateStatus(UpdateTaskStatusModel updateTaskStatusModel);
        void DeleteTask(int id);
    }
}
