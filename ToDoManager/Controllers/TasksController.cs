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
    public class TasksController : BaseController
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
       

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        public  IActionResult CreateTask(CreateUpdateTaskModel taskModel)
        {
            _taskService.CreateTask(taskModel);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(200)]
        public IActionResult UpdateTask(CreateUpdateTaskModel taskModel)
        {
            _taskService.UpdateTask(taskModel);
            return Ok();
        }

    }
}