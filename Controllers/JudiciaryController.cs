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


     [Route("api/judiciary")]
    public class JudiciaryController :  ControllerBase
    {
        private readonly IJudiciaryService judiciaryService;

        public JudiciaryController(IJudiciaryService judiciaryService)
        {
            this.judiciaryService = judiciaryService ??               
                throw new ArgumentNullException(nameof(judiciaryService));
        }


        /// <summary>
        /// Get all current members of the US Supreme Court.
        /// </summary>

        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        public async Task<IActionResult> GetJudiciary()
        {

            return Ok(await this.judiciaryService.GetJudiciary());
            
        }
        /// <summary>
        /// Get a specific supreme court jsutice.
        /// </summary>
        /// <param name="judiciaryId">Id of supreme court jsutice. Example enter 2 for John Roberts</param>

        [HttpGet("{judiciaryId}")]
        [EnableCors("GovLookupPolicy")]
        public async Task<IActionResult> GetJudiciary(string judiciaryId)
        {
            var judiciary = await this.judiciaryService.GetJudiciaryById(judiciaryId);

            if (judiciary == null)
            {
                return NotFound();
            }
            return Ok(judiciary);
        }


    }
}
