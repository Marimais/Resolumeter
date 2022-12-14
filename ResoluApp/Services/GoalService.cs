using DataLayer.DataAccess;
using DataLayer.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ResoluApp.Services
{
    class GoalService : IGoalService
    {
        private readonly ResolutionDBContext _dbContext;
        private readonly ILogger _logger;
        private readonly IResolutionService _resolutionService;
        private readonly AuthenticationStateProvider _authenticationState;
        private string _userName=string.Empty;        

        public GoalService(ResolutionDBContext context, ILogger<GoalService> logger, AuthenticationStateProvider AuthenticationState, IResolutionService resolutionService)
        {
            _dbContext = context;
            _logger = logger;
            _authenticationState = AuthenticationState;
            _resolutionService = resolutionService;
        }

        public void Create(String name, String? description, DateTime endDate)
        {
            try
            {
                Goal goal = new Goal()
                {
                    Name = name,
                    Description = description,
                    EndDate = endDate,
                    ResolutionId = GetResolution(endDate.Year)
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

        public void Edit(int goalId,String name, String? description,Status status, DateTime endDate)
        {
            try
            {
                _dbContext.Goals!.Where(x => x.Id== goalId).ToList().ForEach(x => { x.Name = name;  x.Description = description!; x.Status = status;  x.EndDate = endDate; });
                
                _dbContext.SaveChanges();

                _logger.LogInformation($"Goal has been edited - '{1}'", goalId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update the goal.");
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

        public void Delete(int id)
        {
            try
            {
                var goal = _dbContext.Goals!.Where(g => g.Id == id).SingleOrDefault();
                _dbContext.Goals!.Remove(goal!);
                _dbContext.SaveChanges();
                _logger.LogInformation($"Goal has been removed from databse;");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete the goal.");
            }
        }

        private int GetResolution(int year)
        {            
            Identify _identifier = new(_authenticationState);
            _userName = _identifier.GetUserName().Result!;
            var resolution=_resolutionService.Get(_userName, year);
            if(resolution is null)
            {
                _resolutionService.Create(_userName, year);
                return GetResolution(year);
            }
            else
            {
                return resolution.Id;
            }
        }

    }
}
