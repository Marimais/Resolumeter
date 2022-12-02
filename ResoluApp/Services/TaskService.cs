
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

        public void Edit(int taskId, string name, Status status, string? description, DateTime startDate, DateTime endDate)
        {
            
            try
            {
                _context.Tasks!.Where(t=>t.Id==taskId).ToList().ForEach(t => { t.Name = name; t.Description=description;t.Status = status; t.StartDate = startDate; t.EndDate=endDate; });
                _context.SaveChanges();

                _logger.LogInformation($"Updated Task - {taskId}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not update task.");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var task= _context.Tasks!.Where(t=>t.Id==id).SingleOrDefault();  
                _context.Tasks!.Remove(task!);
                _context.SaveChanges();

                _logger.LogInformation($"Task - has been removed from the Database.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not remove Task from the Database");
            }
        }

    }
}
