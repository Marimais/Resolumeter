using DataLayer.Models;
using Task = DataLayer.Models.Task;

namespace ResoluApp.Services
{
    public interface ITaskService
    {
        void Create(Goal goal, string name, string? description, DateTime startDate, DateTime endDate);
        void Delete(DataLayer.Models.Task task);
        Task? Get(string name);
        List<Task?> GetAll(Goal goal);
    }
}