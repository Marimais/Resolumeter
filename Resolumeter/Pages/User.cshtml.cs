using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.DataAccess;
using DataLayer.Models;
using Task = System.Threading.Tasks.Task;

namespace Resolumeter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.DataAccess.ResolutionContext _context;

        public IndexModel(DataLayer.DataAccess.ResolutionContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users.ToListAsync();
            }
        }
    }
}
