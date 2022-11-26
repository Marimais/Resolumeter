using DataLayer.Models;

namespace ResoluApp.Services
{
    public interface ITaskService
    {
        void Create(int goalId, string name, string? description, DateTime startDate, DateTime endDate, Status status);
        void Delete(DataLayer.Models.Task task);
        DataLayer.Models.Task? Get(int id);
        DataLayer.Models.Task? Get(string name);
        List<DataLayer.Models.Task>? GetAll(int goalId);
    }
}