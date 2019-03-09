using System;
using System.Collections.Generic;

namespace ToDoManager.DataModel
{
    public partial class Users
    {
        public Users()
        {
            Categories = new HashSet<Categories>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ICollection<Categories> Categories { get; set; }
    }
}
