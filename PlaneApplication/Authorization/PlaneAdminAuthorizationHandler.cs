using Microsoft.AspNetCore.Identity;
using PlaneApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace PlaneApplication.Authorization
{
    public class PlaneAdminAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Plane>
    {
        /*UserManager<IdentityUser> _userManager;
        public PlaneCreatorAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
*/
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement, 
            Plane plane)
        {

            if (context.User == null || plane == null)
                return Task.CompletedTask;

            /*if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            if (plane.CreatorId == _userManager.GetUserId(context.User))
                context.Succeed(requirement);

*/
            if (context.User.IsInRole(Constants.PlaneAdminRole))
                context.Succeed(requirement);

            return Task.CompletedTask;

        }
    }
}
