using System;
using System.Collections.Generic;

namespace ToDoManager.DataModel
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Categories Category { get; set; }
    }
}
