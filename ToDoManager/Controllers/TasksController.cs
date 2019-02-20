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
    [Route("api/[controller]/[action]")]
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
        public IActionResult CreateTaskList(CreateUpdateTaskListModel taskListModel)
        {
            _taskService.CreateTaskList(taskListModel);
            return Ok();
        }

        public IActionResult GetTaskList(int userId)
        {
            var tasklists = _taskService.GetTaskList(userId);
            return Ok(tasklists);
        }
    }
}