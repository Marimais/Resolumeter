
using DataLayer.Models;
using DataLayer.DataAccess;
using Task = DataLayer.Models.Task;

namespace ResoluApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ResolutionDBContext _context;
        private readonly ILogger _logger;

        public TaskService(ResolutionDBContext context, ILogger<TaskService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Task>? GetAll(int goalId)
        {
            List<Task>? tasks = new List<Task>();
            try
            {
                tasks = _context.Tasks!.Where(t => t.GoalId == goalId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not retrive tasks for goal - {goalId}");
            }
            return tasks;
        }

        public Task? Get(string name)
        {
            Task? task = default!;
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

        public Task? Get(int id)
        {
            Task? task = default!;
            try
            {
                task = _context.Tasks!.FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find task with Id - {id}");
            }
            return task;
        }

        public void Create(int goalId, string name, string? description, DateTime startDate, DateTime endDate)
        {
            Task task = new()
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                GoalId = goalId,
            };

            try
            {
                _context.Tasks!.Add(task);
                _context.SaveChanges();

                _logger.LogInformation($"Added new Task - {task.Name} for the Goal - {goalId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not create new task for Goal - {goalId}");
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
