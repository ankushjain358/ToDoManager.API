using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoManager.Models
{
    public class TaskListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }
    }
}
