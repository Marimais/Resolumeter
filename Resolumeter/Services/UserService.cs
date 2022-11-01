using DataLayer.DataAccess;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Resolumeter.Services
{
    public static class UserService
    {
        readonly static ResolutionContext _context = new();

        public static User GetUser(string email)
        {
            try
            {
                _context.Database.EnsureCreated();
                return _context.Users!.FirstOrDefault(x => x.Email == email)!;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new User();
            }            
        }

        public static void Add(User user)
        {
            _context.Users!.Add(user);
            _context.SaveChangesAsync();
        }

        public static void Delete(User user)
        {
            _context.Users!.Remove(user);
            _context.SaveChangesAsync();
        }

        public static void Update(User user, string password, string firstName, string lastName)
        {
            User newUser = new()
            {
                Email = user.Email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };

            _context.Users!.Add(newUser);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }

    }
}
