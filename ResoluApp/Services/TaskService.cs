using DataLayer.Models;
using DataLayer.DataAccess;
using Task = DataLayer.Models.Task;

namespace ResoluApp.Services
{
    public static class TaskService
    {
        private static readonly ResolutionContext _context=new();

        public static List<Task> GetAll()
        {
            _context.Database.EnsureCreated();
            return _context.Tasks!.ToList();
        }

        

    }
}
