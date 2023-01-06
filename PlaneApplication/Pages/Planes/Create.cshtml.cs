using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlaneApplication.Authorization;
using PlaneApplication.Data;
using PlaneApplication.Models;

namespace PlaneApplication.Pages.Planes
{
    public class CreateModel : DI_BasePageModel
    {

        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Plane Plane { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            Plane.CreatorId = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Plane, PlaneOperations.Create);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            Context.Plane.Add(Plane);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
