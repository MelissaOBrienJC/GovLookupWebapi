using GovLookup.Business.Contract;
using GovLookup.DataModel;
using GovLookup.Models;
using GovLookupWebapi.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GovLookupWebApi.Controllers
{
    [ApiController, ApiKeyAuth]

    [Route("api/legislators")]
    public class LegislatorsController :  ControllerBase
    {
        private readonly ILegislatorsService legislatorsService;

      
        public LegislatorsController(ILegislatorsService legislatorsService)
        {
            this.legislatorsService = legislatorsService ??               
                throw new ArgumentNullException(nameof(legislatorsService));
        }


        /// <summary>
        /// Get all current members of the US Congress.
        /// </summary>
        /// <param name="searchValue">search value can be a name, partial name or an address examples: Bernie Sanders, Mitch  or 1060 W Addison St, Chicago, IL 60613</param>

        [HttpGet()]
        public IActionResult GetLegislators([FromQuery] string searchValue)
        {

            return Ok(this.legislatorsService.GetLegislators(searchValue));
            
        }


        /// <summary>
        /// Get a specific legislator.
        /// </summary>
        /// <param name="legislatorId">Id of a specific legisltor. Example enter W000817 for Elizabeth Warren</param>

        [HttpGet("{legislatorId}")]

        public IActionResult GetLegislator(string legislatorId)
        {
            var legislator = this.legislatorsService.GetLegislatorById(legislatorId);

            if (legislator == null)
            {
                return NotFound();
            }
            return Ok(legislator);
        }


    }
}
