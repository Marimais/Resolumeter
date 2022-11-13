using DataLayer.Models;
using DataLayer.DataAccess;
using Task = DataLayer.Models.Task;

namespace ResoluApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ResolutionDBContext _context;

        public TaskService(ResolutionDBContext context)
        {
            _context = context;
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
