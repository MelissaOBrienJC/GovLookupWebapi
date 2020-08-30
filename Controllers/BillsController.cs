using GovLookup.Business.Contract;
using GovLookup.DataModel;
using GovLookup.Models;
using GovLookupWebapi.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GovLookupWebApi.Controllers
{
    [ApiController, ApiKeyAuth]

    [Route("api/Bills")]
    public class BillsController :  ControllerBase
    {
        private readonly IBillsService BillsService;

        public BillsController(IBillsService BillsService)
        {
            this.BillsService = BillsService ??               
                throw new ArgumentNullException(nameof(BillsService));
        }


        /// <summary>
        /// Get current bills.
        /// </summary>
     
        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        public IActionResult GetCurrentBills()
        {

            return Ok(this.BillsService.GetCurrentBills());
            
        }

        


    }
}
