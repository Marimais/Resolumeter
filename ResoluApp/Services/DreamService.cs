using DataLayer.DataAccess;
using DataLayer.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace ResoluApp.Services
{
    public class DreamService : IDreamService
    {
        private readonly ResolutionDBContext _context;
        private readonly ILogger _logger;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public DreamService(ResolutionDBContext context, ILogger<DreamService> logger, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _logger = logger;
            _authenticationStateProvider = authenticationStateProvider;
        }


        public void Create(string name, string? description)
        {
            Dream dream = new()
            {
                Name = name,
                Description = description,
                UserName = _authenticationStateProvider.GetAuthenticationStateAsync().Result!.User!.Identity!.Name!
            };
            try
            {
                _context.Dreams!.Add(dream);
                _context.SaveChanges();

                _logger.LogInformation("New dream has been added to DataBase");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create dream", ex);
            }
        }

        public void Edit(int id, string name, string? description)
        {
            try
            {
                _context.Dreams!.Where(d => d.Id == id).ToList().ForEach(d => { d.Name = name; d.Description = description; });

                _logger.LogInformation($"Dream has been updated - {id}.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not update dream.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var dream = _context.Dreams!.Where(d => d.Id == id).SingleOrDefault();
                if (dream is not null) _context.Dreams?.Remove(dream);
                _context.SaveChanges();

                _logger.LogInformation($"Dream {id} has been delete from the Database.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not remove dream from the DataBase", ex);
            }

        }

        public Dream? Get(int id)
        {
            try
            {
                return _context.Dreams!.Where(d => d.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find dream with id -{id}", ex);
                return null;
            }
        }

        public List<Dream>? GetAll(string userName)
        {
            try
            {
                return _context.Dreams!.Where(d => d.UserName == userName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find dreams for user - {userName}", ex);
                return null;
            }
        }

    }
}
