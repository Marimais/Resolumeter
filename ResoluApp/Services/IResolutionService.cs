using DataLayer.Models;

namespace ResoluApp.Services
{
    public interface IResolutionService
    {
        void Create(string userName, string year);
        public List<Resolution> GetAll(string userName);
        public Resolution Get(string userName, string year);
        public void Delete(string userName, string year);
    }
}