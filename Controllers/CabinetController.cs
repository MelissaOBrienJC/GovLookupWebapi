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

    [Route("api/cabinet")]
    public class CabinetController :  ControllerBase
    {
        private readonly ICabinetService cabinetService;

        public CabinetController(ICabinetService cabinetService)
        {
            this.cabinetService = cabinetService ??               
                throw new ArgumentNullException(nameof(cabinetService));
        }


        /// <summary>
        /// Get all current members of the US Cabinet.
        /// </summary>
     
        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        public IActionResult GetCabinet()
        {

            return Ok(this.cabinetService.GetCabinet());
            
        }

        /// <summary>
        /// Get a specific cabinet member.
        /// </summary>
        /// <param name="cabinetId">Id of cabinet number.Example enter 6 for Secretary of the Treasury</param>

        [HttpGet("{cabinetId}")]
        [EnableCors("GovLookupPolicy")]
        public IActionResult GetCabinet(string cabinetId)
        {
            var cabinet = this.cabinetService.GetCabinetById(cabinetId);

            if (cabinet == null)
            {
                return NotFound();
            }
            return Ok(cabinet);
        }


    }
}
