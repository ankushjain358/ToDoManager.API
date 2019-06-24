using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoManager.Models
{
    public class UpdateTaskStatusModel
    {
        public int TaskId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
