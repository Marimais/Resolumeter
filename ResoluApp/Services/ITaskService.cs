namespace ResoluApp.Services
{
    public interface ITaskService
    {
        List<DataLayer.Models.Task> GetAll();
    }
}