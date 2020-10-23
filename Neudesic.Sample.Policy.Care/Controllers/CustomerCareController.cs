using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Neudesic.Sample.Policy.Care.Controllers
{
    public class CustomerCareController : Controller
    {
        [HttpGet("api/[controller]")]
        public IActionResult Version()
        {
            return new OkObjectResult("v.1");
        }


        //*************************************************************
        //require that the user have global care scope
        //*************************************************************
        [Authorize(Constants.Policies.CustomerCare.Policy)]
        [HttpGet("api/[controller]/all")]
        public IActionResult VeiwAll()
        {
            return new OkObjectResult("All Tickets");
        }


        [Authorize(Constants.Policies.CustomerCare.Associate.Policy)]
        [HttpGet("api/[controller]/limited")]
        public IActionResult Payable()
        {
            return new OkObjectResult("Limited");
        }
    }
}
