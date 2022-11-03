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

        public string Message="Hello!";

        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserService.GetUser(User);
            Message = $"Hello {User.FirstName}!";
            return RedirectToPage("./User");
        }

    }
}
