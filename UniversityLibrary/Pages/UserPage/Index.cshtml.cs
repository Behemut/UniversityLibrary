using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Data;
using UniversityLibrary.Models;

namespace UniversityLibrary.Pages.UserPage
{
    public class IndexModel : PageModel
    {
        private readonly UniversityLibrary.Data.DataContext _context;

        public IndexModel(UniversityLibrary.Data.DataContext context)
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
