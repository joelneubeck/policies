using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Neudesic.Sample.Policy
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        public HasScopeHandler()
        {
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            // If user does not have the scope claim, get out of here
            if (!context.User.HasClaim(c => c.Type == "scope"))
                return Task.CompletedTask;

            var scopes = context.User.Claims.Where(
                c => string.Equals(c.Type, "scope", StringComparison.OrdinalIgnoreCase)).ToList();


            foreach (var scope in scopes)
            {
                if(scope.Value == Constants.Policies.Admin.Policy)
                    context.Succeed(requirement);

                if(scope.Value == requirement.Scope)
                    context.Succeed(requirement);

                //if a policy name is comprised of two parts than a user can have a scope
                //of the prefix and access any resources restricted by child policies
                //(i. billing scope can access billing.payable)
                var scopeParts = requirement.Scope.Split(".");
                if(scopeParts.Length > 0)
                {
                    if(scopeParts[0] == scope.Value)
                        context.Succeed(requirement);
                }

            }

            return Task.CompletedTask;
        }
    }
}
