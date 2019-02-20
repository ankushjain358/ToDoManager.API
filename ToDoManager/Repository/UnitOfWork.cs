using ToDoManager.DataModel;

namespace ToDoManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ToDoManagerContext _context;
        private GenericRepository<Users> _userRepository;
        private GenericRepository<Tasks> _taskRepository;
        private GenericRepository<TaskLists> _tasklistRepository;


        public UnitOfWork(ToDoManagerContext context)
        {
            _context = context;
        }

        public IGenericRepository<Users> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<Users>(_context);
                }
                return _userRepository;
            }
        }

        public IGenericRepository<Tasks> TaskRepository
        {
            get
            {
                if (this._taskRepository == null)
                {
                    this._taskRepository = new GenericRepository<Tasks>(_context);
                }
                return _taskRepository;
            }
        }

        public IGenericRepository<TaskLists> TaskListRepository
        {
            get
            {
                if (this._tasklistRepository == null)
                {
                    this._tasklistRepository = new GenericRepository<TaskLists>(_context);
                }
                return _tasklistRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}