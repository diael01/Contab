using Microsoft.AspNetCore.Authorization;

namespace ContabApi.Authorization
{
    public class IsInRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }
        public int ApplicationId { get; set; }
    }
}
