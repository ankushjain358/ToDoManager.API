using System;
using System.Collections.Generic;

namespace ToDoManager.DataModel
{
    public partial class Users
    {
        public Users()
        {
            TaskLists = new HashSet<TaskLists>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ICollection<TaskLists> TaskLists { get; set; }
    }
}
