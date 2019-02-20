using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.DataModel;

namespace ToDoManager.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Users> UserRepository { get; }
        IGenericRepository<Tasks> TaskRepository { get; }
        IGenericRepository<TaskLists> TaskListRepository { get; }
        void SaveChanges();
    }
}
