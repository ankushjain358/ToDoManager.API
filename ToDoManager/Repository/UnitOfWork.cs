using ToDoManager.DataModel;

namespace ToDoManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ToDoManagerContext _context;
        private GenericRepository<Users> _userRepository;
        private GenericRepository<Tasks> _taskRepository;
        private GenericRepository<Categories> _categoryRepository;


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

        public IGenericRepository<Categories> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Categories>(_context);
                }
                return _categoryRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}