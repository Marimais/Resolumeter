using DataLayer.DataAccess;
using DataLayer.Models;

namespace ResoluApp.Services
{
    
    class ResolutionService : IResolutionService
    {
        private readonly ResolutionDBContext _context;
        private readonly ILogger _logger;

        public ResolutionService(ResolutionDBContext context, ILogger<ResolutionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create(string userName, int year)
        {
            try
            {
                Resolution resolution = new()
                {
                    UserName = userName,
                    Year = year
                };

                _context.Resolutions!.Add(resolution);
                _context.SaveChanges();

                _logger.LogInformation($"Created new {1} resolution for user {2}", year, userName);
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

        public Resolution Get(string userName, int year)
        {
            Resolution resolution=default!;
            try
            {
                resolution = _context.Resolutions!.First(a => a.UserName == userName && a.Year == year);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find {year} year resolution for user: {userName}");
            }
            return resolution?? default!; 
        }

        public Resolution Get(int id)
        {
            Resolution resolution = default!;
            try
            {
                resolution = _context.Resolutions!.First(a => a.Id==id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not find resolution for Id: {id}");
            }
            return resolution ?? default!;
        }

        public void Delete(Resolution resolution) 
        {
            try
            {
                _context.Remove(resolution);
                _context.SaveChanges();

                _logger.LogInformation($"Resolution {resolution.Year} has been removed from DataBase.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,$"Couldn't remove year {1} resolution", resolution.Year);
            }
        }

    }
}
