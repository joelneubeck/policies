using System;
namespace Neudesic.Sample.Policy
{
    public static class Constants
    {
        public static class Policies
        {
            public static class Admin
            {
                public const string Policy = "admin";
            }

            public static class Finance
            {
                public const string Policy = "finance";
            }

            public static class Reporting
            {
                public const string Policy = "reporting";
            }
            public static class Billing
            {
                public const string Policy = "billing";

                public static class Receivables
                {
                    public const string Policy = "billing.receivables";
                }

                public static class Payable
                {
                    public const string Policy = "billing.payables";
                }
            }
            
            public static class CustomerCare
            {
                //A user with the default scope has access to any resources that require child policies.
                public const string Policy = "care";
                public static class Associate
                {
                    public const string Policy = "care.associate";
                }
            }
        }
    }
}
