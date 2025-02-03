using Microsoft.AspNetCore.Authorization;
using Services;
using System.Security.Claims;

namespace ContabApi.Authorization
{
    public class IsInRoleHandler : AuthorizationHandler<IsInRoleRequirement>
    {
        private readonly IAuthorizationApiService _AuthorizationApiService;

        public IsInRoleHandler(IAuthorizationApiService authorizationApiService)
        {
            _AuthorizationApiService = authorizationApiService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            IsInRoleRequirement requirement)
        {
            string userId = "1"; //now there is only 1 client
            //todo: here i have to play with retrieving the claims from the user and gettting the CLIENT_ID
            //coz in case of service to service comm, thr eis no userId, thus the code should be generic
            //for users as well as service to service calls
            if (context.User != null && context.User.FindFirst(ClaimTypes.Role) != null)
            {
                userId = context.User.FindFirst(ClaimTypes.Role).Value;
            }
            var permissions = await _AuthorizationApiService
                .GetPermissions(int.Parse(userId), requirement.ApplicationId);

            if (permissions.Role == requirement.Role)
                context.Succeed(requirement);
        }
    }
}
