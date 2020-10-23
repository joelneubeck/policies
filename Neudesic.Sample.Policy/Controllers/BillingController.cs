using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Neudesic.Sample.Policy.Controllers
{
    public class BillingController : Controller
    {
        [HttpGet("api/[controller]")]
        public IActionResult Version()
        {
            return new OkObjectResult("v.1");
        }


        //*************************************************************
        //require that the user have receivables scope or its parent billing
        //*************************************************************
        [Authorize(Constants.Policies.Billing.Receivables.Policy)]
        [HttpGet("api/[controller]/receivables")]
        public IActionResult Receivables()
        {
            return new OkObjectResult("Receivables");
        }


        [Authorize(Constants.Policies.Billing.Payable.Policy)]
        [HttpGet("api/[controller]/payable")]
        public IActionResult Payable()
        {
            return new OkObjectResult("Payable");
        }
    }
}
