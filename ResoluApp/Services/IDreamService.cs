using DataLayer.Models;

namespace ResoluApp.Services
{
    public interface IDreamService
    {
        void Create(string name, string? description);
        void Delete(int id);
        void Edit(int id, string name, string? description);
        Dream? Get(int id);
        List<Dream>? GetAll(string userName);
    }
}