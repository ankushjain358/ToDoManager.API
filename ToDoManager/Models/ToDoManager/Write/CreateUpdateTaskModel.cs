using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoManager.Models
{
    public class CreateUpdateTaskModel
    {
        public int Id { get; set; }
        public int TaskListId { get; set; }
        public string Title { get; set; }
    }
}
