using DataLayer.DataAccess;
using DataLayer.Models;

namespace ResoluApp.Services
{
    public static class UserService
    {
        readonly static ResolutionDBContext _context;

        public static User GetUser(User user)
        {
            throw new NotImplementedException();
            //try
            //{
            //    _context.Database.EnsureCreated();
            //    return _context.Users!.FirstOrDefault(x => x.Email == user.Email && x.Password==user.Password)!;
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    return new User();
            //}            
        }

        public static void Add(User user)
        {
            //_context.Users!.Add(user);
            //_context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public static void Delete(User user)
        {
            //_context.Users!.Remove(user);
            //_context.SaveChangesAsync();
            throw new NotImplementedException();
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

            //_context.Users!.Add(newUser);
            //_context.Users.Remove(user);
            //_context.SaveChangesAsync();
        }

    }
}
