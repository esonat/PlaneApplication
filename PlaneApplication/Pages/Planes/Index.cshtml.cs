using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlaneApplication.Data;
using PlaneApplication.Models;

namespace PlaneApplication.Pages.Planes
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly PlaneApplication.Data.ApplicationDbContext _context;

        public IndexModel(PlaneApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Plane> Plane { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Plane != null)
            {
                Plane = await _context.Plane.ToListAsync();
            }
        }
    }
}
