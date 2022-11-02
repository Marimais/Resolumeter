using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resolumeter.Services;

namespace Resolumeter.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; } = default!;

        public void OnGet()
        {
            
            var user=UserService.GetUser(User);


        }

    }
}
