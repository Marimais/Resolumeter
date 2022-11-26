using DataLayer.DataAccess;
using DataLayer.Models;

namespace ResoluApp.Services
{
    class GoalService : IGoalService
    {
        private readonly ResolutionDBContext _dbContext;
        private readonly ILogger _logger;

        public GoalService(ResolutionDBContext context, ILogger<GoalService> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public void Create(int resolutionId, String name, String? description, DateTime endDate)
        {
            try
            {
                Goal goal = new Goal()
                {
                    Name = name,
                    Description = description,
                    EndDate = endDate,
                    ResolutionId = resolutionId
                };

                _dbContext.Goals!.Add(goal);
                _dbContext.SaveChanges();

                _logger.LogInformation($"Created new goal- '{1}'", goal.Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Goal.");
            }
        }

        public List<Goal>? GetAll(int resolutionId)
        {
            List<Goal>? goals = new List<Goal>();
            try
            {
                goals = _dbContext.Goals!.Where(a => a.ResolutionId == resolutionId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find resolutions for resolution: {1}", resolutionId);
            }
            return goals;
        }

        public Goal? Get(String name)
        {
            Goal? goal = default!;
            try
            {
                goal = _dbContext.Goals!.FirstOrDefault(g => g.Name == name);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find goal with name - {name}");
            }
            return goal;
        }

        public Goal? Get(int id)
        {
            Goal? goal = default!;
            try
            {
                goal = _dbContext.Goals!.FirstOrDefault(g => g.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find goal with Id - {id}");
            }
            return goal;
        }

        public void Delete(Goal goal)
        {
            try
            {
                _dbContext.Goals!.Remove(goal);
                _dbContext.SaveChanges();
                _logger.LogInformation($"Goal {goal.Name} has been removed from databse;");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete goal - {goal.Name}");
            }
        }

    }
}
