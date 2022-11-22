using DataLayer.Models;

namespace ResoluApp.Services
{
    public interface ITaskService
    {
        void Create(Goal goal, string name, string? description, DateTime startDate, DateTime endDate);
        void Delete(DataLayer.Models.Task task);
        DataLayer.Models.Task Get(string name);
        List<DataLayer.Models.Task> GetAll(Goal goal);
    }
}