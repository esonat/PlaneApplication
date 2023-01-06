using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlaneApplication.Authorization;
using PlaneApplication.Data;
using PlaneApplication.Models;

namespace PlaneApplication.Pages.Planes
{
    public class DeleteModel : DI_BasePageModel
    {

        public DeleteModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Plane Plane { get; set; }

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
            /*else 
            {
                Plane = plane;
            }*/
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Plane, PlaneOperations.Delete);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || Context.Plane == null)
            {
                return NotFound();
            }
            Plane = await Context.Plane.FindAsync(id);

            if (Plane == null)
                return NotFound();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Plane, PlaneOperations.Delete);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            Context.Plane.Remove(Plane);
            await Context.SaveChangesAsync();
            

            return RedirectToPage("./Index");
        }
    }
}
