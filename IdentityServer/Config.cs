// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("reporting", "Reporting"),
            new ApiScope("billing", "Billing"),
            new ApiScope("billing.receivables", "Billing receivables"),
            new ApiScope("billing.payable", "Billing Payable"),
            new ApiScope("care", "Customer Care"),
            new ApiScope("care.associate", "Customer Care Associate")
        };

        public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("sampleAPI", "sample resource")
            {
                Scopes =
                {  
                    "reporting",
                    "billing",
                    "billing.receivables",
                    "billing.payables"
                }
            },
            new ApiResource("careAPI", "Care resources")
            {
                Scopes =
                {
                    "care",
                    "care.associate"
                }
            }
        };


        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "40c4b63c-1087-4ab3-b25f-f3cdc44ecf8a",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "reporting", "billing", "care", "sampleAPI" },
                    AlwaysIncludeUserClaimsInIdToken = true
                },
                new Client
                {
                    ClientId = "373c1a4a-1db7-4fbc-be1d-417981afa93d",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "care.associate", "careAPI" },
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
    }
}