﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Neudesic.Sample.Policy
{
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly AuthorizationOptions _options;

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
            _options = options.Value;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            // Check static policies first
            var policy = await base.GetPolicyAsync(policyName);

            if (policy == null)
            {
                policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new HasScopeRequirement(policyName))
                    .Build();

                // Add policy to the AuthorizationOptions, so we don't have to re-create it each time
                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }
    }
}
