using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaneApplication.Authorization;
using PlaneApplication.Data;
using PlaneApplication.Models;

namespace PlaneApplication.Pages.Planes
{
    public class EditModel : DI_BasePageModel
    {
        public EditModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Plane Plane { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || Context.Plane == null)
            {
                return NotFound();
            }

           Plane = await Context.Plane.FirstOrDefaultAsync(m => m.PlaneId == id);
            
            if (Plane == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Plane, PlaneOperations.Update);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var plane = await Context.Plane.AsNoTracking()
                .SingleOrDefaultAsync(m => m.PlaneId == id);

            if (plane == null)
                return NotFound();

            Plane.CreatorId = plane.CreatorId;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Plane, PlaneOperations.Update);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            Context.Attach(Plane).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneExists(Plane.PlaneId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlaneExists(int id)
        {
          return Context.Plane.Any(e => e.PlaneId == id);
        }
    }
}
