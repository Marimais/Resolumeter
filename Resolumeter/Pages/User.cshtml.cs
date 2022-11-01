using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Resolumeter.Services;

namespace Resolumeter.Pages
{
    public class UserModel : PageModel
    {

        [BindProperty]
        public new User User { get; set; } = default!;


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserService.Add(User);

            return RedirectToPage("./User");
        }
    }
}
