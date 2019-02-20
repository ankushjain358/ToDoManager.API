using System;
using System.Collections.Generic;

namespace ToDoManager.DataModel
{
    public partial class TaskLists
    {
        public TaskLists()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }

        public Users User { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
