using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Neudesic.Sample.Policy.Controllers
{
    public class ReportingController : Controller
    {
        [HttpGet("api/[controller]")]
        public IActionResult Version()
        {
            return new OkObjectResult("v.1");
        }

        //*************************************************************
        //require that the user have reporting scope
        //*************************************************************
        [Authorize(Constants.Policies.Reporting.Policy)]
        [HttpGet("api/[controller]/report/edit")]
        public IActionResult EditReport()
        {
            return new OkObjectResult("Edit Report");
        }

        //*********************************************
        //only require a token no specific scopes
        //*********************************************
        [Authorize()]
        [HttpGet("api/[controller]/report")]
        public IActionResult Report()
        {
            return new OkObjectResult("Report");
        }

    }
}
