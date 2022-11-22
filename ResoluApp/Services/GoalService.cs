using DataLayer.DataAccess;
using DataLayer.Models;

namespace ResoluApp.Services
{
    class GoalService : IGoalService
    {
        private readonly ResolutionDBContext _dbContext;
        private readonly ILogger _logger;

        public GoalService(ResolutionDBContext context, ILogger logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public void Create(Resolution resolution, String name, String? description, DateTime endDate)
        {
            try
            {
                Goal goal = new Goal()
                {
                    Name = name,
                    Description = description,
                    EndDate = endDate,
                    Resolution = resolution
                };

                _dbContext.Goals!.Add(goal);
                _dbContext.SaveChanges();

                _logger.LogInformation($"Created new goal- '{1}' for resolution {2}", goal.Name, resolution.Year);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Goal.");
            }
        }

        public List<Goal>? GetAll(Resolution resolution)
        {
            List<Goal>? goals = new List<Goal>();
            try
            {
                goals = _dbContext.Goals!.Where(a => a.Resolution == resolution).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find resolutions for resolution: {1}", resolution.Year);
            }
            return goals;
        }

        public Goal? Get(String name)
        {
            Goal? goal=default!;
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
