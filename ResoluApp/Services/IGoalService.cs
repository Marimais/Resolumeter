using DataLayer.Models;

namespace ResoluApp.Services
{
    internal interface IGoalService
    {
        void Create(string name, string? description, DateTime endDate);
        void Delete(Goal goal);
        Goal? Get(int id);
        Goal? Get(string name);
        List<Goal>? GetAll(int resolutionId);
    }
}