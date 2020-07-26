﻿using GovLookup.Business.Contract;
using GovLookup.DataModel;
using GovLookup.Models;
using GovLookupWebapi.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult GetJudiciary()
        {

            return Ok(this.judiciaryService.GetJudiciary());
            
        }
        /// <summary>
        /// Get a specific supreme court jsutice.
        /// </summary>
        /// <param name="judiciaryId">Id of supreme court jsutice. Example enter 2 for John Roberts</param>

        [HttpGet("{judiciaryId}")]
        public IActionResult GetJudiciary(string judiciaryId)
        {
            var judiciary = this.judiciaryService.GetJudiciaryById(judiciaryId);

            if (judiciary == null)
            {
                return NotFound();
            }
            return Ok(judiciary);
        }


    }
}
