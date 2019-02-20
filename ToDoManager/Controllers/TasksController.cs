using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.Models;
using ToDoManager.Service;

namespace ToDoManager.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        public IActionResult CreateTaskList(CreateUpdateTaskListModel taskListModel)
        {
            _taskService.CreateTaskList(taskListModel);
            return Ok();
        }


        [Route("list/{userId}")]
        [ProducesResponseType(200, Type = typeof(List<TaskListModel>))]
        public IActionResult GetTaskList(int userId)
        {
            var tasklists = _taskService.GetTaskList(userId);
            return Ok(tasklists);
        }
    }
}