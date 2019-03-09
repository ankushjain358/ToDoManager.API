using System.Collections.Generic;

namespace ToDoManager.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<TaskModel> TaskList { get; set; }

        #region Non DB properties
        public int PendingTaskCount { get; set; }
        public int CompletedTaskCount { get; set; }
        #endregion
    }
}
