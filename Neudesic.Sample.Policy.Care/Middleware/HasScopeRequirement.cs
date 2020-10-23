﻿using System;
using Microsoft.AspNetCore.Authorization;

namespace Neudesic.Sample.Policy.Care
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Scope { get; }

        public HasScopeRequirement(string scope)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }
    }
}
