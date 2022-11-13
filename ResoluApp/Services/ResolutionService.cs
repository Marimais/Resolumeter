using DataLayer.DataAccess;
using DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace ResoluApp.Services
{
    
    class ResolutionService : IResolutionService
    {
        private readonly ResolutionDBContext _context;
        private readonly ILogger _logger;

        public ResolutionService(ResolutionDBContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create(string userName, string year)
        {
            try
            {
                Resolution resolution = new()
                {
                    UserName = userName,
                    Year = new DateTime(int.Parse(year), 1, 1)
                };

                _context.Resolutions!.Add(resolution);
                _context.SaveChanges();

                _logger.LogInformation($"Created new {1} resolution for user {1}", year, userName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create resolution.");
            }
        }

        public List<Resolution> GetAll(string userName)
        {
            List<Resolution> resolutions = default!;
            try
            {
                 resolutions = _context.Resolutions!.Where(a=>a.UserName == userName).ToList(); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,$"Could not find resolutions for user: {1}", userName);
            }
            return resolutions;
        }

        public Resolution Get(string userName, string year)
        {
            Resolution resolution=default!;
            try
            {
                DateTime date= DateTime.Parse(year);
                resolution = _context.Resolutions!.First(a => a.UserName == userName && a.Year == date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find {year} year resolution for user: {userName}");
            }
            return resolution?? default!; 
        }

        public void Delete(string userName, string year) 
        {
            try
            {
                DateTime date= DateTime.Parse(year);
                Resolution resolution = _context.Resolutions!.First(a => a.UserName == userName && a.Year == date);
                _context.Remove(resolution);
                _context.SaveChanges();

                _logger.LogInformation($"Removed resolution {resolution.Id}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,$"Couldn't remove year {1} resolution for user: {2}", year, userName);
            }
        }

    }
}
