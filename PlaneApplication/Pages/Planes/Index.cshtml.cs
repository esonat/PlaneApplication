using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlaneApplication.Data;
using PlaneApplication.Models;
using PlaneApplication.Authorization;

namespace PlaneApplication.Pages.Planes
{
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {

        public IndexModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        { 
        }

        //  public IList<Plane> Plane { get;set; } = default!;
        public IList<Plane> Plane { get; set; }
        public async Task OnGetAsync()
        {
            var planes = from i in Context.Plane
                         select i;

            var isAdmin = User.IsInRole(Constants.PlaneAdminRole);
            
            var currentUserId = UserManager.GetUserId(User);

            if(isAdmin == false)
            {
                planes = planes.Where(i => i.CreatorId == currentUserId);
            }

            Plane = await planes.ToListAsync();
            /*Plane = await Context.Plane
                .Where(i => i.CreatorId == currentUserId)
                .ToListAsync();*/
            
        }
    }
}
