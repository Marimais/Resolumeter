using DataLayer.Models;

namespace ResoluApp.Services
{
    internal interface IGoalService
    {
        void Create(Resolution resolution, string name, string? description, DateTime endDate);
        void Delete(Goal goal);
        Goal Get(string name);
        List<Goal> GetAll(Resolution resolution);
    }
}