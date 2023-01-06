using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlaneApplication.Data;
using PlaneApplication.Models;

namespace PlaneApplication.Pages.Planes
{
    public class DeleteModel : PageModel
    {
        private readonly PlaneApplication.Data.ApplicationDbContext _context;

        public DeleteModel(PlaneApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Plane Plane { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plane == null)
            {
                return NotFound();
            }

            var plane = await _context.Plane.FirstOrDefaultAsync(m => m.PlaneId == id);

            if (plane == null)
            {
                return NotFound();
            }
            else 
            {
                Plane = plane;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Plane == null)
            {
                return NotFound();
            }
            var plane = await _context.Plane.FindAsync(id);

            if (plane != null)
            {
                Plane = plane;
                _context.Plane.Remove(Plane);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
