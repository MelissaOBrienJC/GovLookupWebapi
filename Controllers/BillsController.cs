using GovLookup.Business.Contract;
using GovLookup.DataModel;
using GovLookup.Models;
using GovLookupWebapi.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCurrentBills()
        {
            var response = await this.BillsService.GetCurrentBills();

            if (response != null)
                return Ok(response);
            else
                return NotFound("Unable to find any current bills");
                            
            
        }

        


    }
}
