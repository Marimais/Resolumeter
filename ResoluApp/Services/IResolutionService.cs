using DataLayer.Models;

namespace ResoluApp.Services
{
    public interface IResolutionService
    {
        void Create(string userName, int year);
        public List<Resolution> GetAll(string userName);
        public Resolution Get(string userName, int year);
        public void Delete(Resolution resolution);
    }
}