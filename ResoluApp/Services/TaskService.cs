
using DataLayer.Models;
using DataLayer.DataAccess;
using Task = DataLayer.Models.Task;

namespace ResoluApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ResolutionDBContext _context;
        private readonly ILogger _logger;

        public TaskService(ResolutionDBContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Task?> GetAll(Goal goal)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                tasks = _context.Tasks!.Where(t => t.Goal.Equals(goal)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not retrive tasks for goal - {goal.Name}");
            }
            return tasks;
        }

        public Task? Get(string name)
        {
            var task = default!;
            try
            {
                task = _context.Tasks!.FirstOrDefault(t => t.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find task with name - {name}");
            }
            return task;
        }

        public void Create(Goal goal, string name, string? description, DateTime startDate, DateTime endDate)
        {
            Task task = new()
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                Goal = goal,
            };

            try
            {
                _context.Tasks!.Add(task);
                _context.SaveChanges();

                _logger.LogInformation($"Added new Task - {task.Name} for the Goal - {goal.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not create new task for Goal - {goal.Name}");
            }
        }

        public void Delete(Task task)
        {
            try
            {
                _context.Tasks!.Remove(task);
                _context.SaveChanges();

                _logger.LogInformation($"Task - {task.Name} has been removed from the Database.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not remove Task - {task.Name} from the Database");
            }
        }

    }
}
